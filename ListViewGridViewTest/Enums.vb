Public Class Enums
    Public Enum VdisOfflineModes As Integer
        ' The record is loaded in VDIS Central
        None = -1

        ' The record is loaded from xml file in VDIS Offline
        ' in this mode, the record can only be saved to the xml file when there is no connection with server.
        ' If there is a connection, the record may also be uploaded back to the server
        LoadOffline = 0

        ' The Job Order is being exported.
        Export = 1

        UploadToServer = 2
    End Enum

    Public Enum JobStatusValues As Short
        Sales = 0
        InProgress = 1
        Pending = 2
        Cancelled = 3
        Completed = 4
        Incomplete = 5
        Lost = 6
    End Enum

    Public Enum JobApprovedStates As Byte
        NotApproved = 0
        DataChangedSinceApproved = 1
        Approved = 2
    End Enum

    Public Enum CallSheetSections As Integer
        ACCOUNTING = 0
        ASSET = 1
        CONTACT = 2
        DOC = 3
        ENV = 4
        FIELDTEST = 5
        FLUIDS = 6
        FLUIDSEXT = 7
        GEOSCI = 8
        PERFEXT = 9
        PERSONNEL = 10
        RUNS = 11
        SVCSREQ = 12
        TIME = 13
        TREE = 14
        TUBULAR = 15
        UNITS = 16
        WELL = 17
    End Enum

    Public Enum InsertDispatchPersonnelModes As Integer
        ' These modes are used to determine how the insert of a personnel record is controlled within the stored procedures.

        ' This is for inserting from VDIS Web/Central when the Job Order is ONLINE
        ' Bonus data is created/modified as appropriate
        InsertOnlineFromServer = 0

        ' This is for inserting from VDIS Web/Central when the Job Order is OFFLINE
        ' (exported, and being used in the field.  BHI wants to be able to insert personnel from headquarters to keep track of 
        ' who is out on a job)
        ' No bonus data will be generated for these items - they will be deleted when the Job Order is updated from the Offline file.
        InsertOfflineFromServer = 1

        ' This is for updating the server Job Order's personnel from the Offline file when the file is brought back online.
        ' Personnel that were entered under the InsertOfflineFromServer mode will be deleted, and any new ones in the Offline file will replace them.
        ' Bonus data is created/modified as appropriate
        InsertOfflineFromExportedOfflineFile = 2

    End Enum

    Public Enum LqaTypes As Integer
        General = 0
        RCI = 1
        Seismic = 2
    End Enum

    Public Enum FimpNotificationTypes As Integer
        Incident = 1
        CorrectiveActionAssignment = 2
        CorrectiveActionCommunicationInvitation = 3
        ContributingFactorCommunicationInvitation = 4
    End Enum

    Public Enum CompetencyAcquisitionStatuses As Integer
        ' Depending on the use of this enum, the statuses will indicate acquisition of competencies either by employee, or for an entire job.

        ' No employee has acquired a given competency or it has expired for at least one employee
        NoEmployeesAcquiredOrExpired = 0
        ' The at least one employee has acquired the competency
        SomeEmployeesAcquired = 1
        ' The current employee has, or all employees have, acquired a given competency
        CurrentOrAllEmployeesAcquired = 2
    End Enum

    Public Enum DocumentTypes As Integer
        Asset = 0
        Contract = 1
    End Enum

    Public Enum UserAccessTypes As Integer
        CallSheet = 1
        Contract = 2
    End Enum

    Public Enum UserDataGridConfigTypes As Short
        DispOpsDashboard = 1
        RevenueForecast = 2
    End Enum

    Enum DashboardTypes As Short
        DispOpsDashboard = 1
        RevenueForecast = 2
    End Enum

End Class
