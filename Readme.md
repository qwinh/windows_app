Bước 1: chỉnh file App.config theo template này
<!-- App.config.example — commit file này lên git -->
<configuration>
  <connectionStrings>
    <add name="LibraryDB"
         connectionString="Server=TÊN_SERVER_Database_của_tụi_mày\SQLEXPRESS;Database=library;Integrated Security=True;"
         providerName="System.Data.SqlClient" />
  </connectionStrings>
</configuration>
Bước 2: mở .gitignore lên, thêm dòng App.config nếu pull .gitignore về đéo thấy dòng đó
thằng nào làm xong rồi thì cmt vào Readme.md, thằng làm xong cuối xóa cái .md này
hoàng xong
