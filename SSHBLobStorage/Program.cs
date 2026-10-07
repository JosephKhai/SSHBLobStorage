

using Renci.SshNet;

string host = "youraccount.blob.core.windows.net";
int port = 22;
string username = "youraccount.sftpuser";
string password = "YourAzureGeneratedPassword";

string localFilePath = "C:\\Users\\joseph.sektak\\OneDrive - Pentana Solutions\\MDSWarranty\\Deployment List\\DeploymentList.xlsx";
string remoteFilePath = "/wellselectedFile/DeploymentList.xlsx";

var connectionInfo = new ConnectionInfo(host, port, username, new PasswordAuthenticationMethod(username, password));

using (var client = new SftpClient(connectionInfo))
{
    try
    {
        Console.WriteLine("Connecting to the SFTP server...");
        client.Connect();

        using (var fileStream = new FileStream(localFilePath, FileMode.Open))
        {
            Console.WriteLine($"Uploading {localFilePath} to {remoteFilePath}...");
            client.UploadFile(fileStream, remoteFilePath);
            Console.WriteLine("Upload completed successfully.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}


//download file from sftp server
//string localFilePath = "C:/dev/DeploymentList.xlsx";
//string remoteFilePath = "/wellselectedFile/DeploymentList.xlsx";

using (var client = new SftpClient(connectionInfo))
{
    try
    {
        Console.WriteLine("Connecting to the SFTP server...");
        client.Connect();
        using (var fileStream = new FileStream(localFilePath, FileMode.Create))
        {
            Console.WriteLine($"Downloading {remoteFilePath} to {localFilePath}...");
            client.DownloadFile(remoteFilePath, fileStream);
            Console.WriteLine("Download completed successfully.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}