# Context: Library Management (WinForms) — Login & Register + UX

This repo is a **Windows Forms (.NET Framework 4.7.2)** Library Management desktop app written in C#.

Tech stack:
- UI: WinForms
- Data access: ADO.NET
- Database: Microsoft SQL Server (schema already exists)
- Password hashing: `BCrypt.Net-Next`
- “Single session per account” lock: SQL Server `sp_getapplock` with `LockOwner=Session`

---

## 0) Quick onboarding (read this first)

**Authentication table**: `employees` (NOT `readers`).
- `employees.email` is the username (unique)
- `employees.pass` is the BCrypt hash
- `employees.status`: `1=active`, `0=inactive` (inactive users cannot log in)

**Entry point**:
- `Program.cs` starts the app at `LoginRegisterForm` (this is required; do not change it back).

**Auth architecture**:
- `Forms/LoginRegisterForm`: UI only
- `BLL/AuthService`: business rules + BCrypt verify + lock acquisition
- `DAL/UserDAL`: all SQL queries + `sp_getapplock`
- `Helpers/clsDatabase`: connection factory (`CreateOpenConnection()`)
- `Helpers/SessionManager`: holds `CurrentEmployee` + the dedicated lock connection

---

## 1) What’s already implemented (functional requirements)

Login:
- Looks up employee by email
- Blocks inactive accounts (`status=0`)
- Verifies password with BCrypt
- Prevents multiple simultaneous logins of the same account using `sp_getapplock`

Register:
- Validates required fields + minimum password length
- Enforces unique email
- Stores BCrypt hash into `employees.pass`
- After successful register, switches back to Login and pre-fills the login email

---

## 2) Code audit + cleanup (already done on 2026-03-12)

Assume you (the agent) have **0 context**: the following fixes were applied so UX work can safely proceed.

Fixed / refactored:
- `C:\\Users\\ASUS\\Desktop\\LibraryManagement\\Program.cs`: app now starts at `LoginRegisterForm` (previously started at `MainMenu`).
- `C:\\Users\\ASUS\\Desktop\\LibraryManagement\\Forms\\MainMenu.cs`: logout flow no longer creates extra Login forms; main menu always releases the login lock on close; logout now closes the form.
- `C:\\Users\\ASUS\\Desktop\\LibraryManagement\\Forms\\LoginRegisterForm.cs`: fixed register auto-fill bug (it previously cleared `txtRegEmail` before copying to `txtLoginEmail`); improved focus when switching panels; navigation now shows the login form again after main menu closes (no hidden-form accumulation).
- `C:\\Users\\ASUS\\Desktop\\LibraryManagement\\BLL\\AuthService.cs`: trims inputs; adds early required-field validation for login; ensures the dedicated lock connection is always disposed on failures/exceptions.
- `C:\\Users\\ASUS\\Desktop\\LibraryManagement\\DAL\\UserDAL.cs`: login-lock resource is now normalized to lower-case and guaranteed ≤255 chars (uses SHA-256 fallback for very long emails) to avoid `sp_getapplock` failures and case-variant double-login.
- Removed legacy unused helper: `C:\\Users\\ASUS\\Desktop\\LibraryManagement\\Helpers\\clsDatbase.cs` (typo file) to avoid confusion with the real `clsDatabase`.

If you re-audit before UX changes, focus only on login/register-related files above; do not refactor unrelated CRUD forms.

---

## 3) TASK — UX improvements for `LoginRegisterForm`

Goal: keep the current business logic (BLL/DAL/SessionManager) intact, but make login/register feel polished, responsive, and clear.

### Constraints (do NOT violate)
- Do not modify DB schema.
- Do not change login/register business rules in `AuthService`, `UserDAL`, `SessionManager`.
- No third-party UI libraries; keep WinForms built-in controls.
- Keep the “two panels in one form” approach (`pnlLogin`, `pnlRegister`).

### Current control names (must match code)
Login panel:
- `txtLoginEmail`, `txtLoginPassword`, `btnLogin`, `btnGoToRegister`

Register panel:
- `txtRegName`, `txtRegEmail`, `txtRegPassword`, `btnRegister`, `btnGoToLogin`

### Required UX items (implement all)

1) Inline error labels (replace MessageBox for normal validation/auth failures)
- Add `lblLoginError` (red) under the password field in the login panel.
- Add `lblRegisterError` (red) near the bottom of the register panel.
- Only use `MessageBox.Show()` for unexpected exceptions (e.g., DB unreachable).

2) Real-time validation feedback
- Email format validation for `txtLoginEmail` + `txtRegEmail` on `Leave`:
  - If invalid, show a small red label under the field (e.g., `lblLoginEmailError`, `lblRegEmailError`).
  - Clear the field-level error on `TextChanged`.
- Password strength indicator under `txtRegPassword` on `TextChanged`:
  - Weak (red): < 8 chars
  - Medium (orange): 8–11 chars
  - Strong (green): 12+ chars OR has mixed case + digit + special char
- Add confirm-password field:
  - New control `txtRegPasswordConfirm`
  - On `Leave`, if mismatch: show `lblRegPasswordConfirmError` ("Passwords do not match")

3) Show/hide password toggles
- Add checkboxes (or small button) to toggle visibility:
  - `txtLoginPassword`
  - `txtRegPassword`
  - `txtRegPasswordConfirm`
- Implement via `UseSystemPasswordChar` or `PasswordChar` toggle.

4) Loading state (no UI freeze)
- Login/register can take noticeable time (BCrypt + DB). During submit:
  - Disable the submit button to prevent double-submit
  - Change button text to “Signing in…” / “Creating account…”
  - Set cursor to `Cursors.WaitCursor`
  - Restore in `finally`
- Make click handlers `async` and wrap the BLL call in `await Task.Run(() => ...)`.

5) Clear stale errors on interaction
- When the user edits any input after an error, clear:
  - `lblLoginError` (on login panel)
  - `lblRegisterError` (on register panel)
  - Any field-level error labels in the same panel

6) Enter key support
- Press Enter in any login field => triggers login submit.
- Press Enter in any register field => triggers register submit.
- Prefer using `AcceptButton` and update it when switching panels; `KeyDown` is acceptable too.

7) Post-register auto-fill (must keep working)
- After successful register and switching to login, keep pre-filling `txtLoginEmail` with the registered email (already implemented; ensure UX changes don’t break it).

### Output expectations for UX task
1) List every Designer control you added (name, type, parent panel, key properties).
2) Provide updated `LoginRegisterForm.cs` and `LoginRegisterForm.Designer.cs`.
3) Mark every new helper method with a comment `// UX` so review is easy.

