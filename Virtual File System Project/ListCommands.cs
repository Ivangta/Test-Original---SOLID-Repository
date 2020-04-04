using System;
using System.Collections.Generic;
using System.Text;

namespace Virtual_File_System_Project
{
    public class ListCommands
    {
        private Folder root;
        private bool shouldExit;
        Folder currentFolder;
        public ListCommands()
        {
            root = new Folder(null, "root", "root");
            currentFolder = root;
        }

        public void List_Commands()
        {
            Console.WriteLine("\nexit");
            Console.WriteLine("addFile name");
            Console.WriteLine("addFolder name");
            Console.WriteLine("deleteFile name");
            Console.WriteLine("deleteFolder name");
            Console.WriteLine("openFolder name");
            Console.WriteLine("closeFolder");
            Console.WriteLine("list");
            Console.WriteLine("listAll");
        }

        public void ListContents()
        {
            Console.WriteLine();
            var allItems = currentFolder.ListSubItems();
            foreach (var item in allItems)
            {
                var type = ((item is File) ? "file" : "folder");
                Console.WriteLine(item.Name + "      type: " + type + " size: " + item.GetSize() + " created: " + item.CreatedOn);
            }
        }
        public void ListAllContents()
        {
            Console.WriteLine();
            var allItems = GetAllSubItems(root);
            foreach (var item in allItems)
            {
                var type = ((item is File) ? "file" : "folder");
                Console.WriteLine(item.Path + "      type: " + type + " size: " + item.GetSize() + " created: " + item.CreatedOn);
            }
        }

        public List<Container> GetAllSubItems(Folder folder)
        {
            List<Container> allItems = new List<Container>();
            foreach (var item in folder.ListSubItems())
            {
                allItems.Add(item);
                var folderItem = item as Folder;
                if (folderItem != null)
                {
                    var subitems = GetAllSubItems(folderItem);
                    allItems.AddRange(subitems);
                }
            }
            return allItems;
        }
    }
}
