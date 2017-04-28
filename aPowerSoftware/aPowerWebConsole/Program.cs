using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Albert.Power;
using Albert.Power.Win32;
using Microsoft.Win32;
using static System.Console;
using static System.IO.File;
using static Albert.Power.Win32.ConsoleApp;
using static Albert.Power.Win32.Win32IO;
using static Albert.Power.HtmlCore;
using static Albert.Power.Documents;

namespace aPowerWebConsole
{
	class Program
	{

		[STAThread] // For COM realated things  
		static void Main(string[] args)
		{
			//Line 
			var line = "----------------------";
			

			//Startup of The Program 
			void start()
			{
				Clear(); // Clear the Console 

				//Right the Title 
				WriteLine("aPowerWebConsole");
				WriteLine(line);
				WriteLine("Select your task");
				WriteLine(line);
				WriteLine("File Exporter = export\nWordPress = wp\nSite Generatror = site\nAbout = about\nExit = exit\n");


				Write("Type your choice: ");
				var myinput = ReadLine();

				switch (myinput)
				{
					case "export":
						//Run the Export PRogram 
						exportToFolder();
						break;
					case "site":
						pagemaker();
						break;
					case "wp":
						//Run WP
						wp();
						break;
					case "about":
						about();
						break;
					case "exit":
						WriteLine("We are done, Goodbye!");
						WriteLine("Bye!!!");
						break;
					default:
						start();
						break;
				}




			}


			#region WordPress
			//WOrdPress Menu
			void wp()
			{
				Clear();
				WriteLine("WordPress");
				WriteLine("Options\nWordPress Theme = th\nWordPress Plugin= pn\n");
				Write("Type your option here:");
				var opt = ReadLine();

				switch (opt)
				{
					case "th":
						//Run wptheme 
						wptheme();
						break;
					case "pn":
						//Run wpplugin 
						wpplugin();
						break;
					default:
						//Go to Exit or start again 
						ExitProgram(wp, start);
						break;
				}


			}

			//WordPress Theme 
			void wptheme()
			{
				RunProgram("Create a WordPress Theme Folder", wptheme, start, () =>
				{
					var name = "";
					var author = "";
					var version = "";
					Write("Name:");
					name = ReadLine();
					Write("Author:");
					author = ReadLine();
					Write("Version:");
					version = ReadLine();

					var fb = new FolderBrowser(true);

					if (fb.DirectoryInfo == null)
						ExitProgram(wptheme, start);


					var directory = fb.DirectoryInfo; //Grab the selected folder 

					// Create a theme directory 
					var td = directory.CreateSubdirectory(name); // Theme Directory Created 

					//Create some sub folders 
					var img = td.CreateSubdirectory("images"); // Images folder 
					var js = td.CreateSubdirectory("js"); // JavasScript folder 
					var sy = td.CreateSubdirectory("style");// style folder



					//Write the StyleSheet 
					WriteAllText("style.css", WPStyle(name, author, version));


					// Create the theme folder 																													   
					CopyTextFileFromFile("jquery.js", js.FullName, "jquery.js"); // Write a JQuery File
					CopyTextFileFromFile("albert.js", js.FullName, "albert.js"); // Write alebrt.js
					CopyTextFileFromFile("apage.js", js.FullName, "apage.js"); // Write aPage.js
					CopyTextFileFromFile("jalbert.js", js.FullName, "jalbert.js"); // Write jAlbert.js
					CopyTextFileFromFile("flex.scss", sy.FullName, "flex.scss"); // Write flex.scss
					CopyTextFileFromFile("flexui.scss", sy.FullName, "flexui.scss"); // Write flex.scss

					CopyTextFileFromFile("style.css", td.FullName, "style.scss"); // Write style.scss
					CopyTextFileFromFile("style.css", td.FullName, "style.css"); // Write style.css
					CopyTextFileFromFile("wpindex.php", td.FullName, "index.php"); // Write index.php
					CopyTextFileFromFile("wpheader.php", td.FullName, "header.php"); //Write header.php
					CopyTextFileFromFile("wpfooter.php", td.FullName, "footer.php"); //Write footer.php
					CopyTextFileFromFile("wpcontent.php", td.FullName, "content.php"); // Write content.php;
					CopyTextFileFromFile("wppage.php", td.FullName, "page.php"); //Write page.php;
					CopyTextFileFromFile("wpfunctions.php", td.FullName, "functions.php"); //Write functions.php;

					WriteLine("All files have been written...");
					// Go to the exit program 
					ExitProgram(wptheme, start);









				});
			}

			//WordPress Plugin 
			void wpplugin()
			{
				RunProgram("Create a WordPress Plugin Folder", wpplugin, start, () =>
				{
					//Type in the information 
					Write("Name: "); // Name of the Plugin
					var name = ReadLine();
					Write("Aurthor: "); // Author of the Plugin
					var author = ReadLine();
					Write("Version: "); // Version of the Plugin 
					var version = ReadLine();
					Write("License: "); // Lincense of the Plugin 
					var license = ReadLine();

					//Find the WordPress Themes folder to place it in 
					var f = new FolderBrowser(true);


					if (f.DirectoryInfo == null)
						ExitProgram(wpplugin, start);

					var directory = f.DirectoryInfo;
					// Create the Plugin Directory 
					var td = directory.CreateSubdirectory(name); // Theme Directory Created 
																 //Add Sub Folder's to the Directory 
					var img = td.CreateSubdirectory("images"); // Images folder 
					var js = td.CreateSubdirectory("js"); // JavasScript folder 
					var sy = td.CreateSubdirectory("style");// style folder

					//Add to the them directory 
					//File dump 
					var plugininfo = $"<?php\n\n/*\nPlugin Name: {name}\nAuthor: {author}\nVersion: {version}\nLicense: {license}\n\n?>"; // Let WordPress know
																																		  //Write style.css and style.scss
					WriteAllText("functions.php", plugininfo);

					// Create the theme folder 																													   
					CopyTextFileFromFile("jquery.js", js.FullName, "jquery.js"); // Write a JQuery File
					CopyTextFileFromFile("albert.js", js.FullName, "albert.js"); // Write alebrt.js
					CopyTextFileFromFile("apage.js", js.FullName, "apage.js"); // Write aPage.js
					CopyTextFileFromFile("jalbert.js", js.FullName, "jalbert.js"); // Write jAlbert.js
					CopyTextFileFromFile("flex.scss", sy.FullName, "flex.scss"); // Write flex.scss
					CopyTextFileFromFile("flexui.scss", sy.FullName, "flex.scss"); // Write flex.scss
					CopyTextFileFromFile("gwfonts.scss", sy.FullName, "gwfonts.scss"); // Write gwfonts
					CopyTextFileFromFile("style.scss", td.FullName, "style.scss"); // Write style.scss
					CopyTextFileFromFile("style.scss", td.FullName, "style.css"); // Write style.css
					CopyTextFileFromFile("wpfunctions.php", td.FullName, "functions.php"); //Write functions.php;

					WriteLine("All files have ben written...");
					// Go to the exit program 
					ExitProgram(wpplugin, start);
				});
			}

			#endregion


			#region Html Genrator 

			//page maker 
			void pagemaker()
			{

				//Page Genrator 
				RunProgram("Html Page Maker", pagemaker, start, () =>
				{
					string description, keywords, author;
					CoreList<string> styleList, scripts;
					CoreList<HtmlPage> pages;
					psetup(out description, out keywords, out author, out styleList, out scripts, out pages);


					//var temp = new HtmlTemp(description, keywords, author);
					var preview = HtmlDoc(description, keywords, author, "Title", styleList, scripts);
					//Spit out html file 
					WriteLine(preview);
					//Save Options 
					WriteLine("Do you want to export this website to a folder?");
					Write("Type here (y/n): ");
					var export = ReadLine();

					switch (export)
					{
						case "y":
							Write("Site Name:");
							//Name your site
							var sname = ReadLine();

							var fb = new FolderBrowser(true);
							var dir = fb?.DirectoryInfo;
							// Create the Main Directory 
							var mf = dir?.CreateSubdirectory(sname);
							//Create images folder 
							var img = mf.CreateSubdirectory("images");
							//Create style folder 
							var mstyle = mf.CreateSubdirectory("styles");
							pages.ForEach((page) =>
							{
								var path = Path.Combine(mf.FullName, page.PageName);


								//Create the Content 
								var content = HtmlCore.HtmlDoc(description, keywords, author, page.PageTitle, styleList, scripts);
								//Write the Page 
								WriteAllText(path, content);

							});
							WriteLine("All Done!");
							ExitProgram(pagemaker, start);


							break;
						default:
							var fb2 = new FolderBrowser(true);
							var dir2 = fb2?.DirectoryInfo;

							pages.ForEach((page) =>
							{
								var path = Path.Combine(dir2.FullName, page.PageName);
								// Create the Content 
								var content2 = HtmlCore.HtmlDoc(description, keywords, author, page.PageTitle, styleList, scripts);

								//Write the Page 
								WriteAllText(path, content2);

							});
							WriteLine("All Done!");
							ExitProgram(pagemaker, start);

							break;
					}

				});
			}


			void psetup(out string description, out string keywords, out string author, out CoreList<string> styleList, out CoreList<string> scripts, out CoreList<HtmlPage> pages)
			{
				//Field's 
				description = "";
				keywords = "";
				author = "";

				//Define desciption of the website
				Write("Description: ");
				description = ReadLine();
				//Define the keywords 
				Write("Keywords: ");
				keywords = ReadLine();
				//Define the Author 
				Write("Author: ");
				author = ReadLine();

				styleList = new CoreList<string>();
				var addStyle = true;

				while (addStyle == true)
				{
					Write("Stylesheet: ");
					var sty = ReadLine();
					styleList.Add(sty);

					Write("Do you want add a another style?(y/n):  ");

					var op = ReadLine();

					if (op == "y")
					{
						addStyle = true;
					}
					else
					{
						addStyle = false;
					}
				}


				scripts = new CoreList<string>();
				var addScript = true;

				while (addScript == true)
				{
					Write("Script: ");
					var sc = ReadLine();
					scripts.Add(sc);

					Write("Do you want add a another script?(y/n):  ");

					var op1 = ReadLine();

					if (op1 == "y")
					{
						addScript = true;
					}
					else
					{
						addScript = false;
					}

				}

				pages = new CoreList<HtmlPage>();
				var addPage = true;

				while (addPage == true)
				{
					Write("Page Name:");
					var p = ReadLine();
					Write("Page Title:");
					var t = ReadLine();
					pages.Add(new HtmlPage(p, t));

					Write("Do you want create another page?\n");
					Write("Type here(y/n):");
					var np = ReadLine();

					switch (np)
					{
						case "y":
							addPage = true;
							break;
						case "n":
							addPage = false;
							break;
						default:
							addPage = false;
							break;
					}

				}

			}
			#endregion

		
			void about()
			{
				var ashow = true;

				while (ashow == true)
				{
					Clear();
					WriteLine("About\n************\naPowerWebConsole\n\nCreated by\nAlbert M. Byrd\n");

					Write("Go back start menu(y/n): ");
					var str = ReadLine();

					switch (str)
					{
						case "y":
							
							ashow = false;
							//RUn the start 
							start();
							
							break;
						default:
							//Run the about method again
							ashow = true;
							break;
					}
				}

			}

			void exportToFolder()
			{
				RunProgram("Export files to a Folder", exportToFolder, start, () =>
				{

					//Default Filter for the OpenDialog 
					var filter = "All Formsts(.)|*.*";
					var importing = true;
					//List of the Files that have been 
					var fileList = new CoreList<FileInfo>();



					var opt = "";
					// do while importing == true; 
					while (importing == true)
					{

						//Do the OpenDialogTask Lamba 
						OpenDialogTask("Pick your Export Files", filter, (dialog) =>
						{
							if (dialog.FileName != null)
							{
								foreach (var file in dialog.FileNames)
								{
									//Grab the name of each selected file 
									var fi = new FileInfo(file); // Create a file info for them 
									fileList.Add(fi); // Add them to the file list


								}
								// ForEach Lamba 
								fileList.ForEach((file) =>
								{
									// Show the file name of each item you import 
									WriteLine($"Exported File: {file.Name}");
								});


							}
						});
						// Do you want to add more files? 
						Write("Do you want to export more files?(y/n): ");
						opt = ReadLine();

						switch (opt)
						{
							case "y":
								importing = true;
								break;
							default:
								importing = false;
								break;
						}
					}
					switch (fileList.Count)
					{
						case 0:
							// Go to the  Exit 
							ExitProgram(exportToFolder, start);
							break;
						default:
							Write("Do you want to copy files to new folder? (y/n): ");
							var rd = ReadLine();

							switch (rd)
							{
								case "y":

									var f = new FolderBrowser(true);


									if (f.DirectoryInfo == null)
										ExitProgram(exportToFolder, start);

									var dir = f?.DirectoryInfo;

									fileList.ForEach((file) =>
									{
										var path = Path.Combine(dir.FullName, file.Name);
										file.CopyTo(path, true);
									});

									// Go to the  Exit 
									ExitProgram(exportToFolder, start);

									break;
								default:
									// Go to the  Exit 
									ExitProgram(exportToFolder, start);
									break;
							}
							break;
					}

				});


			}

			start();

			ReadLine();

		}
	}

	public class HtmlPage
	{
		public HtmlPage(string _name, string _title)
		{
			PageName = _name;
			PageTitle = _title;
		}

		public string PageName { get; }

		public string PageTitle { get; }
	}

}
