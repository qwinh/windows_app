# Agent Task — Replace Hardcoded Emoji/Unicode Icons with FontAwesome.Sharp

This repo is a **WinForms (.NET Framework 4.7.2)** Library Management desktop app.

---

## ⚠️ FIRST STEP — Read the Entire Codebase Before Changing Anything

Before modifying any file, scan and read **every `.cs` and `.Designer.cs` file** under `Forms/`.

For each file, look for and log:
1. Any `Label`, `Button`, or control whose `.Text` is set to an **emoji** (e.g. `"📚"`, `"👤"`, `"📖"`, `"🔙"`)
2. Any `.Text` assigned a **unicode escape** used as an icon (e.g. `"\uE736"`, `"\uE77B"`)
3. Any `Font` set to `"Segoe UI Emoji"` or `"Segoe MDL2 Assets"` specifically for icon rendering
4. Any `Label` or `Button` that is clearly named `lblIcon`, `lblSidebarIcon`, `lblBookIcon`, or similar icon-purpose names

Build a complete list of every occurrence before proceeding. Do not change anything yet.

---

## Objective

Replace **every hardcoded emoji / unicode icon** in the codebase with a proper **FontAwesome.Sharp** control, so:
- Icons are vector-crisp at all DPIs
- No more magic strings or unicode codepoints in source code
- Icon identity is explicit and refactor-friendly (e.g. `IconChar.BookOpen` not `"📚"`)
- Visual appearance stays consistent with the existing app style (same colors, same sizes)

---

## Step 1 — Install FontAwesome.Sharp

In the project's **NuGet Package Manager**, install:

```
FontAwesome.Sharp version 6.x.x (latest stable)
```

Or via Package Manager Console:
```powershell
Install-Package FontAwesome.Sharp
```

Add the using directive wherever needed:
```csharp
using FontAwesome.Sharp;
```

---

## Step 2 — Replacement Rules

### Case A — A `Label` used purely as an icon (no text beside it)

**Before:**
```csharp
this.lblBookIcon.Font = new Font("Segoe UI Emoji", 28f);
this.lblBookIcon.Text = "📚";
```

**After:** Replace the `Label` in the Designer with an `IconPictureBox`:
```csharp
// In Designer.cs — replace Label declaration with:
this.iconSidebar = new FontAwesome.Sharp.IconPictureBox();

// Properties:
this.iconSidebar.IconChar  = FontAwesome.Sharp.IconChar.BookOpen;
this.iconSidebar.IconColor = Color.FromArgb(92, 179, 255);
this.iconSidebar.IconSize  = 36;
this.iconSidebar.BackColor = Color.Transparent;
this.iconSidebar.Size      = new Size(40, 40);
// copy over original Location, Anchor, Margin from the old label
```

---

### Case B — A `Button` with an emoji prepended to text

**Before:**
```csharp
this.btnProfile.Text = "👤 My Profile";
```

**After:** Replace the `Button` with an `IconButton`:
```csharp
// In Designer.cs:
this.btnProfile = new FontAwesome.Sharp.IconButton();

this.btnProfile.IconChar         = FontAwesome.Sharp.IconChar.UserCircle;
this.btnProfile.IconColor        = Color.White;
this.btnProfile.IconSize         = 18;
this.btnProfile.ImageAlign       = ContentAlignment.MiddleLeft;
this.btnProfile.Text             = "My Profile";   // no emoji prefix
this.btnProfile.TextAlign        = ContentAlignment.MiddleLeft;
this.btnProfile.TextImageRelation = TextImageRelation.ImageBeforeText;
// copy over original BackColor, ForeColor, FlatStyle, Size, Location, etc.
```

---

### Case C — A `Label` that mixes an emoji with actual text

**Before:**
```csharp
this.lblStatus.Text = "📖 Currently borrowing 3 books";
```

**After:** Split into two controls — an `IconPictureBox` for the icon + the original `Label` for text, placed side by side in a `FlowLayoutPanel` or positioned manually.

```csharp
// Icon part:
this.iconStatus = new FontAwesome.Sharp.IconPictureBox();
this.iconStatus.IconChar  = FontAwesome.Sharp.IconChar.Book;
this.iconStatus.IconColor = Color.FromArgb(50, 60, 80);
this.iconStatus.IconSize  = 16;
this.iconStatus.Size      = new Size(20, 20);
this.iconStatus.BackColor = Color.Transparent;

// Text part (keep existing label, just remove the emoji prefix):
this.lblStatus.Text = "Currently borrowing 3 books";
```

---

## Step 3 — Icon Mapping Reference

Use this table to pick the correct `IconChar` for each use case found in the codebase.
If you find an emoji not listed here, choose the closest semantic match from FontAwesome.Sharp's `IconChar` enum.

| Location / Purpose            | Old Emoji / Unicode     | Replacement `IconChar`          |
|-------------------------------|-------------------------|---------------------------------|
| Sidebar app logo              | `📚` / `📖`             | `IconChar.BookOpen`             |
| Manage Books button/card      | `📚` / `📖`             | `IconChar.Book`                 |
| Manage Readers button/card    | `👥` / `👤`             | `IconChar.Users`                |
| Borrow Book button/card       | `➡️` / `📤`             | `IconChar.ArrowRightFromBracket`|
| Return Book button/card       | `⬅️` / `📥`             | `IconChar.ArrowLeftToBracket`   |
| My Profile button             | `👤`                    | `IconChar.CircleUser`           |
| Exit button                   | `🚪` / `✖`              | `IconChar.RightFromBracket`     |
| Back / navigation             | `🔙` / `←`              | `IconChar.ArrowLeft`            |
| Login / auth                  | `🔐` / `🔑`             | `IconChar.RightToBracket`       |
| Logout                        | `🚪`                    | `IconChar.RightFromBracket`     |
| Search                        | `🔍`                    | `IconChar.MagnifyingGlass`      |
| Edit / pencil                 | `✏️`                    | `IconChar.PenToSquare`          |
| Save                          | `💾`                    | `IconChar.FloppyDisk`           |
| Error / warning               | `⚠️`                    | `IconChar.TriangleExclamation`  |
| Success / check               | `✅`                    | `IconChar.CircleCheck`          |

---

## Step 4 — Designer.cs Cleanup Rules

After replacing each control, make sure to:

1. **Remove** the old `Label`/`Button` declaration and all its property assignments from `Designer.cs`.
2. **Add** the new `IconPictureBox` / `IconButton` declaration and its properties in the same position.
3. **Update** `this.Controls.Add(...)` and `this.SuspendLayout()` / `this.ResumeLayout()` sections to reference the new control name.
4. **Update** the field declaration at the top of the `Designer.cs` partial class:
   ```csharp
   // Remove:
   private System.Windows.Forms.Label lblBookIcon;
   
   // Add:
   private FontAwesome.Sharp.IconPictureBox iconSidebar;
   ```
5. If the old control was referenced in `Form.cs` (the non-designer file) — update those references too.
6. Do **not** leave orphaned field declarations or `InitializeComponent` references to deleted controls.

---

## Step 5 — Preserve All Existing Styling

When replacing a control, carry over these properties exactly from the original:
- `Location`, `Size`, `Anchor`, `Dock`, `Margin`, `Padding`
- `BackColor` (keep `Transparent` for icons on colored backgrounds)
- `TabIndex`, `TabStop = false` (icons should not be tab-focusable)
- Any event handlers attached (e.g. `Click` events on icon-buttons)

Do **not** change layout, spacing, or colors of surrounding controls.

---

## Step 6 — Verify No Emoji/Unicode Strings Remain

After all replacements, do a final search across all `.cs` files for:
- Any remaining string containing emoji characters
- Any `Font` still set to `"Segoe UI Emoji"` or `"Segoe MDL2 Assets"` for icon purposes
- Any `\uXXXX` escape used as a visual icon

If any are found, replace them following the same rules above.

---

## Naming Convention for New Controls

| Control type      | Naming pattern               | Example                  |
|-------------------|------------------------------|--------------------------|
| `IconPictureBox`  | `icon` + purpose             | `iconSidebar`, `iconBack`|
| `IconButton`      | `btn` + purpose (keep name)  | `btnProfile`, `btnExit`  |

Do **not** use generic names like `iconPictureBox1`.

---

## Deliverables (provide after all changes)

1. **Full replacement log** — table with columns:
   - File changed
   - Old control name + type
   - New control name + type
   - `IconChar` used
2. **Files modified** — every `.cs` and `.Designer.cs` touched.
3. **Confirmation** that no emoji / unicode icon strings remain in the codebase.
4. **Confirmation** that `FontAwesome.Sharp` is added to the project references and the package is installed.

---

## Acceptance Criteria

- Zero hardcoded emoji or unicode icon strings remain anywhere in `.cs` files.
- Every replaced control renders the correct semantic icon via `FontAwesome.Sharp`.
- Visual layout is pixel-equivalent to before (no shifted controls, no size changes).
- App compiles and runs without errors after migration.
- No orphaned field declarations or broken `InitializeComponent` references.
