using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual_File_System_Project
{
    public class NavigationService
    {
        private readonly Execute_Command executeCommand;
        private readonly ListCommands listCommands;
        private readonly ListCommands listContents;
        private readonly ListCommands listAllContent;
        private readonly ListCommands getAllSubItems;
        private Folder root;
        private bool shouldExit;
        Folder currentFolder;
        public NavigationService(Execute_Command executeCommand, ListCommands listCommands, ListCommands listContents, ListCommands listAllContent, ListCommands getAllSubitems)
        {
            this.executeCommand = executeCommand;
            this.listCommands = listCommands;
            this.listContents = listContents;
            this.listAllContent = listAllContent;
            this.getAllSubItems = getAllSubitems;
            root = new Folder(null, "root", "root");
            currentFolder = root;
        }

        public NavigationService()
        {
        }

        public void StartProgram()
        {
            while (!shouldExit)
            {
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(currentFolder.Path);
                Console.WriteLine("Input a command: (type \"commands\" to list all commands)");
                string command = Console.ReadLine();
                ExecuteCommand(command);
                Console.WriteLine("------------------------------------------------");
            }
        }


        public void ExecuteCommand(string command)
        {
            executeCommand.ExecuteCommand(command);
        }

        public void List_Commands()
        {
            listCommands.List_Commands();
        }

        public void ListContents()
        {
            listCommands.ListContents();
        }
        public void ListAllContents()
        {
            listCommands.ListAllContents();
        }
        public void GetAllSubItems(Folder folder)
        {
            listCommands.GetAllSubItems(folder);
        }



    }
}
