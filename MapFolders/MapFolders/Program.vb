Imports System
Imports System.IO

Module Program
    Private Sub recursiveFunct(path As String)
        Try
            Dim dir As New DirectoryInfo(path)
            Dim directories As DirectoryInfo() = dir.GetDirectories().OrderByDescending(Function(p) p.CreationTime).ToArray()
            If Directory.Exists(path) Then
                For Each directory2 As DirectoryInfo In directories
                    ' Console.WriteLine(directory.Name)
                    recursiveFunct(path + directory2.Name + "\")
                    Console.WriteLine(path + directory2.Name + "\desktop.ini")
                    Dim tempPath As String = path + directory2.Name + "\desktop.ini"
                    Dim fPath = tempPath
                    If File.Exists(path + directory2.Name + "\desktop.ini") Then

                        'System.IO.Directory.CreateDirectory(tempPath)

                        File.Delete(tempPath)


                        Dim afile As New IO.StreamWriter(fPath, True)
                        afile.WriteLine("[.ShellClassInfo]")
                        afile.WriteLine("IconResource=" + Directory.GetCurrentDirectory.Substring(0, 3) +
                                        "Pictures\FolderIcon.ico,0")
                        afile.WriteLine("[ViewState]")
                        afile.WriteLine("Mode =")
                        afile.WriteLine("Vid =")
                        afile.WriteLine("FolderType =Generic")
                        afile.Close()
                        Dim t As New FileInfo(tempPath)
                        t.Attributes = FileAttributes.Hidden


                    Else
                        Dim afile As New IO.StreamWriter(fPath, True)
                        afile.WriteLine("[.ShellClassInfo]")
                        afile.WriteLine(Directory.GetCurrentDirectory.Substring(0, 3) +
                                        "Pictures\FolderIcon.ico,0")
                        afile.Close()
                        Dim t As New FileInfo(tempPath)
                        t.Attributes = FileAttributes.Hidden

                    End If
                Next
            End If
        Catch e As Exception
            Console.WriteLine(e)
        End Try
    End Sub
    Sub Main(args As String())

        'Console.WriteLine(Directory.GetCurrentDirectory.Substring(0, 3))
        If (Directory.GetCurrentDirectory.ElementAt(0) <> "C"c) Then
            Dim path As String = (Directory.GetCurrentDirectory.Substring(0, 3))
            recursiveFunct(path)
        Else
            Console.WriteLine("Access Denied!")
        End If

    End Sub



End Module
