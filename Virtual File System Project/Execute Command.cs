using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual_File_System_Project
{
    public class Execute_Command
    {
        private readonly ListCommands listCommands;
        private Folder root;
        private bool shouldExit;
        Folder currentFolder;
        public Execute_Command(ListCommands listCommands)
        {
            this.listCommands = listCommands;
            root = new Folder(null, "root", "root");
            currentFolder = root;
        }

        public void ExecuteCommand(string command)
        {
            var commandDetails = command.Split(" ");
            switch (commandDetails[0])
            {
                case "exit":
                    shouldExit = true;
                    break;
                case "addFile":
                    currentFolder.Add(new File(currentFolder, commandDetails[1], (currentFolder.Path + "/" + commandDetails[1])));
                    break;
                case "addFolder":
                    currentFolder.Add(new Folder(currentFolder, commandDetails[1], (currentFolder.Path + "/" + commandDetails[1])));
                    break;
                case "deleteFile":
                    currentFolder.Remove(currentFolder.GetFileByName(commandDetails[1]));
                    break;
                case "deleteFolder":
                    currentFolder.Remove(currentFolder.GetFolderByName(commandDetails[1]));
                    break;
                //case "list":
                //    ListContents();
                //    break;
                //case "listAll":
                //    ListAllContents();
                //    break;
                case "commands":
                    listCommands.List_Commands();
                    break;
                case "openFolder":
                    var targetFolder = currentFolder.GetFolderByName(commandDetails[1]);
                    if (targetFolder != null)
                    {
                        currentFolder = targetFolder;
                    }
                    else
                    {
                        Console.WriteLine("#Error folder does not exist");
                    }
                    break;
                case "closeFolder":
                    var targetFolder2 = currentFolder.Parent;
                    if (targetFolder2 != null)
                    {
                        currentFolder = targetFolder2;
                    }
                    else
                    {
                        Console.WriteLine("#Error You are at the root");
                    }
                    break;
                default:
                    Console.WriteLine("Command does not exist");
                    break;
            }
        }
    }
}
