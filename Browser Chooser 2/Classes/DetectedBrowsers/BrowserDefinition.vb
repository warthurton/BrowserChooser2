﻿<Serializable()> _
Public Class BrowserDefinition
    <Serializable()> _
    Public Class NonAdminPath
        Public Enum SpecialFolders
            LocalApplicationPath
            SystemApps
        End Enum
        Public SpecialFolder As SpecialFolders
        Public FinalSection As String

        Public Shared Function GetSpecialFolder(ByVal aSpecialFolder As SpecialFolders) As String
            Select Case aSpecialFolder
                Case SpecialFolders.LocalApplicationPath
                    Return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                Case SpecialFolders.SystemApps
                    Return Environment.GetFolderPath(Environment.SpecialFolder.System)
                Case Else
                    Return Nothing
            End Select
        End Function
    End Class

    Public Structure AlternativeExecutionDetails
        Public Path As String
        Public Arguments As String

        Sub New(ByVal aPath As String, ByVal aArguments As String)
            Me.Path = aPath
            Me.Arguments = aArguments
        End Sub
    End Structure

    Public Name As String
    Public FolderName As String 'to be used only if whilecard ending is true
    Public AlternativeExecution As AlternativeExecutionDetails 'to be used only if universal - how to start it
    Public InstallPath As List(Of String)
    Public ExecutePath As List(Of String)
    Public IsIE As Boolean = False
    Public IsUniversalApp As Boolean = False 'must launch differently
    Public SupportsNonAdmin As Boolean = False
    Public NonAdminInstallPath As List(Of NonAdminPath)
    Public DefaultIconIndex As Integer = 0
    Public DefaultIconPath As String = "" ' overrides icon index
    Public HasWilcardEndingToPath As Boolean = False ' for use with MS edge and other Metro based broswers
End Class
