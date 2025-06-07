Imports System.Collections.ObjectModel

Public Class GlobalData

    Private Shared moLookupDataManager As New LookupDataManager

    Private Shared mcolAcquisitionList As List(Of GetListResult)
    Public Shared Async Function GetAcquisitionList() As Task(Of List(Of GetListResult))
        Try
            If mcolAcquisitionList Is Nothing Then
                mcolAcquisitionList = Await moLookupDataManager.GetAcquisitionListAsync
                If mcolAcquisitionList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolAcquisitionList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetAcquisitionList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolAssetPmPtCalcTriggerFields As List(Of GetAssetPmPointCalculationTriggerDispFieldsResult)
    Public Shared Async Function GetAssetPmPtCalcTriggerFields() As Task(Of List(Of GetAssetPmPointCalculationTriggerDispFieldsResult))
        Try
            If mcolAssetPmPtCalcTriggerFields Is Nothing Then
                mcolAssetPmPtCalcTriggerFields = Await moLookupDataManager.GetAssetPmPointCalculationTriggerDispFieldRecordsAsync()
                If mcolAssetPmPtCalcTriggerFields Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolAssetPmPtCalcTriggerFields
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetAssetPmPtCalcTriggerFields", True)
        End Try
        Return New List(Of GetAssetPmPointCalculationTriggerDispFieldsResult)
    End Function

    Public Shared ReadOnly Property AssetPmPtCalcTriggerFields As List(Of GetAssetPmPointCalculationTriggerDispFieldsResult)
        Get
            Return If(mcolAssetPmPtCalcTriggerFields, New List(Of GetAssetPmPointCalculationTriggerDispFieldsResult))
        End Get
    End Property

    Private Shared mcolBlindRamsList As List(Of GetListResult)
    Public Shared Async Function GetBlindRamsList() As Task(Of List(Of GetListResult))
        Try
            If mcolBlindRamsList Is Nothing Then
                mcolBlindRamsList = Await moLookupDataManager.GetBlindRamsListAsync
                If mcolBlindRamsList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolBlindRamsList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetBlindRamsList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolChargeCaseList As List(Of GetListResult)
    Public Shared Async Function GetChargeCaseList() As Task(Of List(Of GetListResult))
        Try
            If mcolChargeCaseList Is Nothing Then
                mcolChargeCaseList = Await moLookupDataManager.GetChargeCaseListAsync
                If mcolChargeCaseList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolChargeCaseList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetChargeCaseList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolChargeTypeList As List(Of GetListResult)
    Public Shared Async Function GetChargeTypeList() As Task(Of List(Of GetListResult))
        Try
            If mcolChargeTypeList Is Nothing Then
                mcolChargeTypeList = Await moLookupDataManager.GetChargeTypeListAsync
                If mcolChargeTypeList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolChargeTypeList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetChargeTypeList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolConcentrationList As List(Of GetListResult)
    Public Shared Async Function GetConcentrationList() As Task(Of List(Of GetListResult))
        Try
            If mcolConcentrationList Is Nothing Then
                mcolConcentrationList = Await moLookupDataManager.GetConcentrationListAsync
                If mcolConcentrationList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolConcentrationList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetConcentrationList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolCountyList As List(Of GetCountyListResult)
    Public Shared Async Function GetCountyList() As Task(Of List(Of GetCountyListResult))
        Try
            If mcolCountyList Is Nothing Then
                mcolCountyList = Await moLookupDataManager.GetCountyListAsync
                If mcolCountyList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolCountyList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetCountyList", True)
        End Try
        Return New List(Of GetCountyListResult)
    End Function

    Public Shared ReadOnly Property CountyList As List(Of GetCountyListResult)
        Get
            Return If(mcolCountyList, New List(Of GetCountyListResult))
        End Get
    End Property

    Public Shared Async Function GetCountyDesc(countyId As String) As Task(Of String)
        Try
            Dim loCounty = Await GetCounty(countyId)
            If loCounty Is Nothing Then
                Exit Try
            End If

            Return loCounty.county_desc.Trim
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetCountyDesc", True)
        End Try
        Return ""
    End Function

    Public Shared Async Function GetCounty(countyId As String) As Task(Of GetCountyListResult)
        Try
            Return (Await GetCountyList()).FirstOrDefault(Function(r) StringsAreEqual(r.county_id, countyId))
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetCounty", True)
        End Try
        Return Nothing
    End Function

    Private Shared mcolCurrencyList As List(Of GetListResult)
    Public Shared Async Function GetCurrencyList() As Task(Of List(Of GetListResult))
        Try
            If mcolCurrencyList Is Nothing Then
                mcolCurrencyList = Await moLookupDataManager.GetCurrencyListAsync
                If mcolCurrencyList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolCurrencyList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetCurrencyList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolCustomerList As List(Of GetCompanyListResult)
    Public Shared Async Function GetCustomerList() As Task(Of List(Of GetCompanyListResult))
        Try
            If mcolCustomerList Is Nothing Then
                mcolCustomerList = Await moLookupDataManager.GetCustomerListAsync
                If mcolCustomerList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolCustomerList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetCustomerList", True)
        End Try
        Return New List(Of GetCompanyListResult)
    End Function

    Public Shared Function CustomerList() As List(Of GetCompanyListResult)
        Return If(mcolCustomerList, New List(Of GetCompanyListResult))
    End Function

    Public Shared Function FilteredCustomerList(Optional currentOilcompId As String = Nothing) As List(Of GetCompanyListResult)
        Try
            ' Filter out inactive Customer records.
            ' If currentOilcompId has a value, include it in the list so that old jobs, etc. with this Customer
            ' will display properly (IE, the Customer ComboBox will have the correct Customer selected).
            Dim lcolActiveCustomers = mcolCustomerList.Where(Function(c) Not c.inactive_flag OrElse StringsAreEqual(currentOilcompId, c.oilcomp_id))
            If lcolActiveCustomers IsNot Nothing AndAlso lcolActiveCustomers.Count > 0 Then
                Return lcolActiveCustomers.ToList
            End If
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "Filtered Customer ItemsSource", True)
        End Try
        Return mcolCustomerList
    End Function

    Public Shared Async Function GetCustomerName(oilcompId As String) As Task(Of String)
        Try
            Dim loCustomer = Await GetCustomer(oilcompId)
            If loCustomer Is Nothing Then
                Exit Try
            End If

            Return loCustomer.name.Trim
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetCustomerName", True)
        End Try
        Return ""
    End Function

    Public Shared Async Function GetCustomer(oilcompId As String) As Task(Of GetCompanyListResult)
        Try
            Return (Await GetCustomerList()).FirstOrDefault(Function(c) StringsAreEqual(c.oilcomp_id, oilcompId))
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetCustomer", True)
        End Try
        Return Nothing
    End Function

    Private Shared mcolDensityList As List(Of GetListResult)
    Public Shared Async Function GetDensityList() As Task(Of List(Of GetListResult))
        Try
            If mcolDensityList Is Nothing Then
                mcolDensityList = Await moLookupDataManager.GetDensityListAsync
                If mcolDensityList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolDensityList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetDensityList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolDepthList As List(Of GetListResult)
    Public Shared Async Function GetDepthList() As Task(Of List(Of GetListResult))
        Try
            If mcolDepthList Is Nothing Then
                mcolDepthList = Await moLookupDataManager.GetDepthListAsync
                If mcolDepthList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolDepthList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetDepthList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolDeviceBelowList As List(Of GetListResult)
    Public Shared Async Function GetDeviceBelowList() As Task(Of List(Of GetListResult))
        Try
            If mcolDeviceBelowList Is Nothing Then
                mcolDeviceBelowList = Await moLookupDataManager.GetPerfDeviceBelowListAsync
                If mcolDeviceBelowList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolDeviceBelowList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetDeviceBelowList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolDispConfigSectionList As List(Of GetDispConfigSectionsResult)
    Public Shared Async Function GetDispConfigSectionsList() As Task(Of List(Of GetDispConfigSectionsResult))
        Try
            If mcolDispConfigSectionList Is Nothing Then
                mcolDispConfigSectionList = Await moLookupDataManager.GetDispConfigSectionListAsync
                If mcolDispConfigSectionList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolDispConfigSectionList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetDispConfigSectionsList", True)
        End Try
        Return New List(Of GetDispConfigSectionsResult)
    End Function

    Public Shared Function DispSectionConfiguredForPsl(callSheetSection As Enums.CallSheetSections, psl As String) As Boolean
        Try
            Return mcolDispConfigSectionList.Any(Function(s) StringsAreEqual(s.section_id, callSheetSection.ToString) AndAlso StringsAreEqual(s.psl_id, psl))
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - DispSectionConfiguredForPsl", True)
        End Try
        Return False
    End Function

    Private Shared mcolDispatchToolbarColorList As List(Of DispatchToolbarColor)
    Public Shared Function GetDispatchToolbarColorList() As List(Of DispatchToolbarColor)
        If mcolDispatchToolbarColorList Is Nothing Then
            mcolDispatchToolbarColorList = New List(Of DispatchToolbarColor)
            mcolDispatchToolbarColorList.Add(New DispatchToolbarColor("D", "Default"))
            mcolDispatchToolbarColorList.Add(New DispatchToolbarColor("R", "Red"))
            mcolDispatchToolbarColorList.Add(New DispatchToolbarColor("O", "Orange"))
            mcolDispatchToolbarColorList.Add(New DispatchToolbarColor("Y", "Yellow"))
            mcolDispatchToolbarColorList.Add(New DispatchToolbarColor("G", "Green"))
            mcolDispatchToolbarColorList.Add(New DispatchToolbarColor("B", "Blue"))
            mcolDispatchToolbarColorList.Add(New DispatchToolbarColor("P", "Purple"))
        End If
        Return mcolDispatchToolbarColorList
    End Function

    Public Shared Function GetDispatchToolbarColor(colorCode As String) As DispatchToolbarColor
        Try
            Return GetDispatchToolbarColorList.FirstOrDefault(Function(c) StringsAreEqual(c.ColorCode, colorCode))
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetDispatchToolbarColor", True)
        End Try
        Return Nothing
    End Function

    Private Shared mcolDistanceList As List(Of GetListResult)
    Public Shared Async Function GetDistanceList() As Task(Of List(Of GetListResult))
        Try
            If mcolDistanceList Is Nothing Then
                mcolDistanceList = Await moLookupDataManager.GetDistanceListAsync
                If mcolDistanceList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolDistanceList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetDistanceList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolDistrictList As List(Of district)
    Public Shared Async Function GetDistrictList() As Task(Of List(Of district))
        Try
            If mcolDistrictList Is Nothing Then
                mcolDistrictList = Await moLookupDataManager.GetDistrictListAsync
                If mcolDistrictList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolDistrictList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetDistrictList", True)
        End Try
        Return New List(Of district)
    End Function

    Public Shared Function DistrictList() As List(Of district)
        Return If(mcolDistrictList, New List(Of district))
    End Function

    Public Shared Function FilteredDistrictList(Optional currentDistId As Integer? = Nothing) As List(Of district)
        Try
            ' Filter out inactive District records.
            ' If currentDistId has a value, include it in the list so that old jobs, etc. with this District
            ' will display properly (IE, the District ComboBox will have the correct District selected).
            Dim lcolActiveDistricts = mcolDistrictList.Where(Function(d) Not d.inactive_flag OrElse
                                                                                (currentDistId.HasValue AndAlso d.dist_id = currentDistId))
            If lcolActiveDistricts IsNot Nothing AndAlso lcolActiveDistricts.Count > 0 Then
                Return lcolActiveDistricts.ToList
            End If
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "Filtered District List", True)
        End Try
        Return mcolDistrictList
    End Function

    Public Shared Async Function GetDistrictName(distId As Integer) As Task(Of String)
        Try
            Dim loDistrict = Await GetDistrict(distId)
            If loDistrict Is Nothing Then
                Exit Try
            End If

            Return loDistrict.name
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetDistrictName", True)
        End Try
        Return ""
    End Function

    Public Shared Async Function GetDistrictCurrencyCode(distId As Integer) As Task(Of String)
        Try
            Dim loDistrict = Await GetDistrict(distId)
            If loDistrict Is Nothing Then
                Exit Try
            End If

            Return loDistrict.currency_code
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetDistrictCurrencyCode", True)
        End Try
        Return ""
    End Function

    Public Shared Async Function GetDisplayGrossRevenueFlag(distId As Integer) As Task(Of Boolean)
        Try
            Dim loDistrict = Await GetDistrict(distId)
            If loDistrict Is Nothing Then
                Exit Try
            End If

            Return loDistrict.display_gross_revenue_flag
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetDisplayGrossRevenueFlag", True)
        End Try
        Return False
    End Function

    Public Shared Async Function GetReportLanguage(distId As Integer) As Task(Of String)
        Try
            Dim loDistrict = Await GetDistrict(distId)
            If loDistrict Is Nothing Then
                Exit Try
            End If

            Return loDistrict.report_language
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetReportLanguage", True)
        End Try
        Return ""
    End Function

    Public Shared Async Function GetPlantId(distId As Integer) As Task(Of String)
        Try
            Dim loDistrict = Await GetDistrict(distId)
            If loDistrict Is Nothing Then
                Exit Try
            End If

            Return loDistrict.plant_id
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetPlantId", True)
        End Try
        Return "0"
    End Function

    Public Shared Async Function GetTerritory(distId As Integer) As Task(Of String)
        Try
            Dim loDistrict = Await GetDistrict(distId)
            If loDistrict Is Nothing Then
                Exit Try
            End If

            Return loDistrict.territory
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetTerritory", True)
        End Try
        Return ""
    End Function

    Public Shared Async Function GetDistrictHasCompletedSvcAuthReport(distId As Integer) As Task(Of Boolean)
        Try
            Dim loDistrict = Await GetDistrict(distId)
            If loDistrict Is Nothing Then
                Exit Try
            End If

            Return loDistrict.has_cmpl_svc_auth_report_flag
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - DistrictHasCompletedSvcAuthReport", True)
        End Try
        Return False
    End Function

    Public Shared Async Function GetDistrictCountryCode(distId As Integer) As Task(Of String)
        Try
            Dim loDistrict = Await GetDistrict(distId)
            If loDistrict Is Nothing Then
                Exit Try
            End If

            Return loDistrict.country_code
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetDistrictCountryCode", True)
        End Try
        Return ""
    End Function

    Public Shared Async Function GetDistrictLocationType(distId As Integer) As Task(Of String)
        Try
            Dim loDistrict = Await GetDistrict(distId)
            If loDistrict Is Nothing Then
                Exit Try
            End If

            Return loDistrict.location_type
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetDistrictLocationType", True)
        End Try
        Return ""
    End Function

    Public Shared Async Function GetDistrictDisplayProvince(distId As Integer) As Task(Of Boolean)
        Try
            Dim loDistrict = Await GetDistrict(distId)
            If loDistrict Is Nothing Then
                Exit Try
            End If

            Return loDistrict.display_province_flag
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetDistrictDisplayProvince", True)
        End Try
        Return False
    End Function

    Public Shared Async Function GetDistrictDisplayLegalDescription(distId As Integer) As Task(Of Boolean)
        Try
            Dim loDistrict = Await GetDistrict(distId)
            If loDistrict Is Nothing Then
                Exit Try
            End If

            Return loDistrict.display_legal_desc_flag
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetDistrictDisplayLegalDescription", True)
        End Try
        Return False
    End Function

    Public Shared Async Function GetDistrictDisplayWellLicense(distId As Integer) As Task(Of Boolean)
        Try
            Dim loDistrict = Await GetDistrict(distId)
            If loDistrict Is Nothing Then
                Exit Try
            End If

            Return loDistrict.display_well_license_flag
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetDistrictDisplayWellLicense", True)
        End Try
        Return False
    End Function

    Public Shared Async Function GetDistrictApiUwiDigitsOnly(distId As Integer) As Task(Of Boolean)
        Try
            Dim loDistrict = Await GetDistrict(distId)
            If loDistrict Is Nothing Then
                Exit Try
            End If

            Return loDistrict.api_uwi_digits_only_flag
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetDistrictApiUwiDigitsOnly", True)
        End Try
        Return False
    End Function

    Public Shared Async Function GetDistrict(distId As Integer) As Task(Of district)
        Try
            Return (Await GetDistrictList()).FirstOrDefault(Function(district) district.dist_id = distId)
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetDistrict", True)
        End Try
        Return Nothing
    End Function

    Private Shared mcolDrillerLevelList As List(Of GetListResult)
    Public Shared Async Function GetDrillerLevelList() As Task(Of List(Of GetListResult))
        Try
            If mcolDrillerLevelList Is Nothing Then
                mcolDrillerLevelList = Await moLookupDataManager.GetDrillerLevelListAsync()
                If mcolDrillerLevelList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolDrillerLevelList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetDrillerLevelListList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Public Shared ReadOnly Property DrillerLevelList As List(Of GetListResult)
        Get
            Return If(mcolDrillerLevelList, New List(Of GetListResult))
        End Get
    End Property

    Public Shared Async Function GetDrillerLevel(drillerLevelCode As String) As Task(Of String)
        Try
            If Trim(drillerLevelCode & "").Length > 2 Then
                drillerLevelCode = drillerLevelCode.Substring(0, 2)
            End If

            Dim loDrillerLevel = (Await GetDrillerLevelList()).FirstOrDefault(Function(l) StringsAreEqual(l.list_item, drillerLevelCode))
            If loDrillerLevel IsNot Nothing Then
                Return loDrillerLevel.list_item
            End If
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetDrillerLevel", True)
        End Try
        Return Nothing
    End Function

    Private Shared mcolEnvironmentList As List(Of GetEnvironmentListResult)
    Public Shared Async Function GetEnvironmentList() As Task(Of List(Of GetEnvironmentListResult))
        Try
            If mcolEnvironmentList Is Nothing Then
                mcolEnvironmentList = Await moLookupDataManager.GetEnvironmentListAsync()
                If mcolEnvironmentList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolEnvironmentList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetEnvironmentList", True)
        End Try
        Return New List(Of GetEnvironmentListResult)
    End Function

    Public Shared ReadOnly Property EnvironmentList As List(Of GetEnvironmentListResult)
        Get
            Return If(mcolEnvironmentList, New List(Of GetEnvironmentListResult))
        End Get
    End Property

    Public Shared Async Function GetEnvironmentDescription(environmentId As Short) As Task(Of String)
        Try
            Dim loEnvironment = Await GetEnvironment(environmentId)
            If loEnvironment Is Nothing Then
                Exit Try
            End If

            Return loEnvironment.environment_desc
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetEnvironmentDescription", True)
        End Try
        Return ""
    End Function

    Public Shared Async Function GetEnvironment(environmentId As Short) As Task(Of GetEnvironmentListResult)
        Try
            Return (Await GetEnvironmentList()).FirstOrDefault(Function(e) e.environment_id = environmentId)
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetEnvironment", True)
        End Try
        Return Nothing
    End Function

    Private Shared mcolExplosiveTypeList As List(Of GetListResult)
    Public Shared Async Function GetExplosiveTypeList() As Task(Of List(Of GetListResult))
        Try
            If mcolExplosiveTypeList Is Nothing Then
                mcolExplosiveTypeList = Await moLookupDataManager.GetExplosiveTypeListAsync()
                If mcolExplosiveTypeList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolExplosiveTypeList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetExplosiveTypeList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolFiringHeadList As List(Of GetListResult)
    Public Shared Async Function GetFiringHeadList() As Task(Of List(Of GetListResult))
        Try
            If mcolFiringHeadList Is Nothing Then
                mcolFiringHeadList = Await moLookupDataManager.GetFiringHeadListAsync()
                If mcolFiringHeadList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolFiringHeadList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetFiringHeadList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolFluidInfoSourceList As List(Of GetListResult)
    Public Shared Async Function GetFluidInfoSourceList() As Task(Of List(Of GetListResult))
        Try
            If mcolFluidInfoSourceList Is Nothing Then
                mcolFluidInfoSourceList = Await moLookupDataManager.GetFluidInfoSourceListAsync()
                If mcolFluidInfoSourceList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolFluidInfoSourceList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetFluidInfoSourceList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolFluidSourceList As List(Of GetListResult)
    Public Shared Async Function GetFluidSourceList() As Task(Of List(Of GetListResult))
        Try
            If mcolFluidSourceList Is Nothing Then
                mcolFluidSourceList = Await moLookupDataManager.GetFluidSourceListAsync()
                If mcolFluidSourceList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolFluidSourceList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetFluidSourceList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Public Shared ReadOnly Property FluidSourceList As List(Of GetListResult)
        Get
            Return If(mcolFluidSourceList, New List(Of GetListResult))
        End Get
    End Property

    Public Shared Async Function GetFluidSource(fluidSourceCode As String) As Task(Of String)
        Try
            Dim loFluidSource = (Await GetFluidSourceList()).FirstOrDefault(Function(l) StringContainsSubstring(l.list_item, fluidSourceCode))
            If loFluidSource IsNot Nothing Then
                Return loFluidSource.list_item
            End If
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetFluidSource", True)
        End Try
        Return Nothing
    End Function

    Private Shared mcolFluidTypeList As List(Of GetListResult)
    Public Shared Async Function GetFluidTypeList() As Task(Of List(Of GetListResult))
        Try
            If mcolFluidTypeList Is Nothing Then
                mcolFluidTypeList = Await moLookupDataManager.GetFluidTypeListAsync()
                If mcolFluidTypeList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolFluidTypeList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetFluidTypeList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Public Shared ReadOnly Property FluidTypeList As List(Of GetListResult)
        Get
            Return If(mcolFluidTypeList, New List(Of GetListResult))
        End Get
    End Property

    Private Shared mcolGunSizeList As List(Of GetListResult)
    Public Shared Async Function GetGunSizeList() As Task(Of List(Of GetListResult))
        Try
            If mcolGunSizeList Is Nothing Then
                mcolGunSizeList = Await moLookupDataManager.GetGunSizeListAsync()
                If mcolGunSizeList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolGunSizeList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetGunSizeList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolGunTypeList As List(Of GetListResult)
    Public Shared Async Function GetGunTypeList() As Task(Of List(Of GetListResult))
        Try
            If mcolGunTypeList Is Nothing Then
                mcolGunTypeList = Await moLookupDataManager.GetGunTypeListAsync()
                If mcolGunTypeList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolGunTypeList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetGunTypeList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolHoleSizeList As List(Of GetListResult)
    Public Shared Async Function GetHoleSizeList() As Task(Of List(Of GetListResult))
        Try
            If mcolHoleSizeList Is Nothing Then
                mcolHoleSizeList = Await moLookupDataManager.GetHoleSizeListAsync()
                If mcolHoleSizeList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolHoleSizeList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetHoleSizeList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolInstrProtectionList As List(Of GetListResult)
    Public Shared Async Function GetInstrProtectionList() As Task(Of List(Of GetListResult))
        Try
            If mcolInstrProtectionList Is Nothing Then
                mcolInstrProtectionList = Await moLookupDataManager.GetInstrumentProtectionListAsync()
                If mcolInstrProtectionList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolInstrProtectionList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetInstrProtectionList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolLengthList As List(Of GetListResult)
    Public Shared Async Function GetLengthList() As Task(Of List(Of GetListResult))
        Try
            If mcolLengthList Is Nothing Then
                mcolLengthList = Await moLookupDataManager.GetLengthListAsync()
                If mcolLengthList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolLengthList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetLengthList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolOperationList As List(Of GetListResult)
    Public Shared Async Function GetOperationList() As Task(Of List(Of GetListResult))
        Try
            If mcolOperationList Is Nothing Then
                mcolOperationList = Await moLookupDataManager.GetOperationListAsync()
                If mcolOperationList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolOperationList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetOperationList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolPerfIntervalPolarityList As List(Of GetPerfIntervalPolarityListResult)
    Public Shared Async Function GetPerfIntervalPolarityList() As Task(Of List(Of GetPerfIntervalPolarityListResult))
        Try
            If mcolPerfIntervalPolarityList Is Nothing Then
                mcolPerfIntervalPolarityList = Await moLookupDataManager.GetPerfIntervalPolarityListAsync()
                If mcolPerfIntervalPolarityList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolPerfIntervalPolarityList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetPerfIntervalPolarityList", True)
        End Try
        Return New List(Of GetPerfIntervalPolarityListResult)
    End Function

    Public Shared ReadOnly Property PerfIntervalPolarityList As List(Of GetPerfIntervalPolarityListResult)
        Get
            Return If(mcolPerfIntervalPolarityList, New List(Of GetPerfIntervalPolarityListResult))
        End Get
    End Property


    Private Shared mcolPlantList As List(Of GetPlantsResult)
    Public Shared Async Function GetPlantList(filteredList As Boolean, includeInactivePlants As Boolean) As Task(Of List(Of GetPlantsResult))
        Try
            If mcolPlantList Is Nothing Then
                mcolPlantList = Await moLookupDataManager.GetPlantListAsync(filteredList, includeInactivePlants)
                If mcolPlantList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolPlantList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetPlantList", True)
        End Try
        Return New List(Of GetPlantsResult)
    End Function

    Public Shared ReadOnly Property PlantList As List(Of GetPlantsResult)
        Get
            Return If(mcolPlantList, New List(Of GetPlantsResult))
        End Get
    End Property

    Private Shared mcolPriceScheduleList As List(Of GetPriceScheduleRecordsResult)
    Public Shared Async Function GetPriceScheduleList() As Task(Of List(Of GetPriceScheduleRecordsResult))
        Try
            If mcolPriceScheduleList Is Nothing Then
                mcolPriceScheduleList = Await moLookupDataManager.GetPriceScheduleRecordsAsync()
                If mcolPriceScheduleList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolPriceScheduleList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetPriceScheduleList", True)
        End Try
        Return New List(Of GetPriceScheduleRecordsResult)
    End Function

    Public Shared Function PriceScheduleList() As List(Of GetPriceScheduleRecordsResult)
        Return If(mcolPriceScheduleList, New List(Of GetPriceScheduleRecordsResult))
    End Function

    Public Shared Function FilteredPriceScheduleList(Optional currentPriceSchedule As String = "") As List(Of GetPriceScheduleRecordsResult)
        Try
            ' Filter out inactive Price Schedule records.
            ' If currentPriceSchedule is not empty, include it in the list so that old FSOs, etc. with this Price Schedule
            ' will display properly (IE, the Price Schedule ComboBox will have the correct Price Schedule selected).
            Dim lcolActivePriceSchedules = mcolPriceScheduleList.Where(Function(ps) Not ps.inactive_flag OrElse
                                                                                  StringsAreEqual(currentPriceSchedule, ps.price_schedule_id))
            If lcolActivePriceSchedules IsNot Nothing AndAlso lcolActivePriceSchedules.Count > 0 Then
                Return lcolActivePriceSchedules.ToList
            End If
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "Filtered Price Schedule List", True)
        End Try

        Return mcolPriceScheduleList
    End Function

    Public Shared Async Function GetPriceSchedule(priceScheduleId As String) As Task(Of GetPriceScheduleRecordsResult)
        Try
            Return (Await GetPriceScheduleList()).FirstOrDefault(Function(ps) StringsAreEqual(ps.price_schedule_id, priceScheduleId))
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetPriceSchedule", True)
        End Try
        Return Nothing
    End Function

    Private Shared mcolProspectList As List(Of GetListResult)
    Public Shared Async Function GetProspectList() As Task(Of List(Of GetListResult))
        Try
            If mcolProspectList Is Nothing Then
                mcolProspectList = Await moLookupDataManager.GetProspectListAsync()
                If mcolProspectList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolProspectList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetProspectList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolProvinceList As List(Of ProvinceListItem)
    Public Shared Function GetProvinceList() As List(Of ProvinceListItem)
        If mcolProvinceList Is Nothing Then
            mcolProvinceList = New List(Of ProvinceListItem)
            mcolProvinceList.Add(New ProvinceListItem() With {.province = "Alberta"})
            mcolProvinceList.Add(New ProvinceListItem() With {.province = "British Columbia"})
            mcolProvinceList.Add(New ProvinceListItem() With {.province = "Manitoba"})
            mcolProvinceList.Add(New ProvinceListItem() With {.province = "New Brunswick"})
            mcolProvinceList.Add(New ProvinceListItem() With {.province = "Newfoundland & Labrador"})
            mcolProvinceList.Add(New ProvinceListItem() With {.province = "Nova Scotia"})
            mcolProvinceList.Add(New ProvinceListItem() With {.province = "Northwest Territories"})
            mcolProvinceList.Add(New ProvinceListItem() With {.province = "Nunavut"})
            mcolProvinceList.Add(New ProvinceListItem() With {.province = "Ontario"})
            mcolProvinceList.Add(New ProvinceListItem() With {.province = "Prince Edward Island"})
            mcolProvinceList.Add(New ProvinceListItem() With {.province = "Quebec"})
            mcolProvinceList.Add(New ProvinceListItem() With {.province = "Saskatchewan"})
            mcolProvinceList.Add(New ProvinceListItem() With {.province = "Yukon Territories"})
        End If
        Return mcolProvinceList
    End Function

    Private Shared mcolPslList As List(Of GetPSLListResult)
    Public Shared Async Function GetPslList() As Task(Of List(Of GetPSLListResult))
        Try
            If mcolPslList Is Nothing Then
                mcolPslList = Await moLookupDataManager.GetPslListAsync()
                If mcolPslList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolPslList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetPslList", True)
        End Try
        Return New List(Of GetPSLListResult)
    End Function

    Public Shared ReadOnly Property PslList As List(Of GetPSLListResult)
        Get
            Return mcolPslList
        End Get
    End Property

    Public Shared Async Function GetPslName(pslId As String) As Task(Of String)
        Try
            Dim loPsl = Await GetPsl(pslId)
            If loPsl Is Nothing Then
                Exit Try
            End If

            Return loPsl.psl_name.Trim
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetPslName", True)
        End Try
        Return ""
    End Function

    Public Shared Async Function GetPslVisualId(pslId As String) As Task(Of String)
        Try
            Dim loPsl = Await GetPsl(pslId)
            If loPsl Is Nothing Then
                Exit Try
            End If

            Return loPsl.display_id.Trim
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetPslVisualId", True)
        End Try
        Return ""
    End Function

    Public Shared Async Function GetPslDispatchTypeAsync(pslId As String) As Task(Of String)
        Try
            Dim loPsl = Await GetPsl(pslId)
            If loPsl Is Nothing Then
                Exit Try
            End If

            Return loPsl.dispatch_type.Trim
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetPslDispatchTypeAsync", True)
        End Try
        Return ""
    End Function

    Public Shared Function GetPslDispatchType(pslId As String) As String
        Try
            Return mcolPslList.FirstOrDefault(Function(psl) psl.psl_id = pslId)?.dispatch_type.Trim
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetPslDispatchType", True)
        End Try
        Return ""
    End Function

    Public Shared Async Function GetPsl(pslId As String) As Task(Of GetPSLListResult)
        Try
            Return (Await GetPslList()).FirstOrDefault(Function(psl) psl.psl_id = pslId)
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetPsl", True)
        End Try
        Return Nothing
    End Function

    Private Shared mcolRhaList As List(Of GetListResult)
    Public Shared Async Function GetRhaList() As Task(Of List(Of GetListResult))
        Try
            If mcolRhaList Is Nothing Then
                mcolRhaList = Await moLookupDataManager.GetRhaListAsync()
                If mcolRhaList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolRhaList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetRhaList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolRigList As List(Of GetRigRecordsResult)
    Public Shared Async Function GetRigList() As Task(Of List(Of GetRigRecordsResult))
        Try
            If mcolRigList Is Nothing Then
                mcolRigList = Await moLookupDataManager.GetRigListAsync()
                If mcolRigList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolRigList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetRigList", True)
        End Try
        Return New List(Of GetRigRecordsResult)
    End Function

    Public Shared ReadOnly Property RigList As List(Of GetRigRecordsResult)
        Get
            Return If(mcolRigList, New List(Of GetRigRecordsResult))
        End Get
    End Property

    Public Shared Async Function GetRigName(rigId As String) As Task(Of String)
        Try
            Dim loRig = Await GetRig(rigId)
            If loRig Is Nothing Then
                Exit Try
            End If

            Return loRig.rig_name.Trim
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetRigName", True)
        End Try
        Return ""
    End Function

    Public Shared Async Function GetRig(rigId As String) As Task(Of GetRigRecordsResult)
        Try
            Return (Await GetRigList()).FirstOrDefault(Function(r) StringsAreEqual(r.rig_id, rigId))
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetRig", True)
        End Try
        Return Nothing
    End Function

    Private Shared mcolRigTypeList As List(Of GetListResult)
    Public Shared Async Function GetRigTypeList() As Task(Of List(Of GetListResult))
        Try
            If mcolRigTypeList Is Nothing Then
                mcolRigTypeList = Await moLookupDataManager.GetRigTypeListAsync()
                If mcolRigTypeList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolRigTypeList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetRigTypeList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolRunStandbyServiceList As List(Of RunStandbyService)
    Public Shared Async Function GetRunStandbyServiceList() As Task(Of List(Of RunStandbyService))
        Try
            If mcolRunStandbyServiceList Is Nothing Then
                mcolRunStandbyServiceList = New List(Of RunStandbyService)

                Dim lcStandbyServiceIds As String = Await moLookupDataManager.GetRunStandbyServiceIdsAsync()
                If String.IsNullOrWhiteSpace(lcStandbyServiceIds) Then
                    Exit Try
                End If

                Dim laStandbyTypes() As String = lcStandbyServiceIds.Split(";")
                For Each lcServiceId In laStandbyTypes(0).Split(",")
                    ' Runs with these services will have their calculated times logged as Operating Time.
                    mcolRunStandbyServiceList.Add(New RunStandbyService(lcServiceId.Trim, False))
                Next
                For Each lcServiceId In laStandbyTypes(1).Split(",")
                    ' Runs with these services will have their calculated times logged as Standby Time.
                    mcolRunStandbyServiceList.Add(New RunStandbyService(lcServiceId.Trim, True))
                Next
            End If
            Return mcolRunStandbyServiceList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetRunStandbyServiceList", True)
        End Try
        Return New List(Of RunStandbyService)
    End Function

    Public Shared ReadOnly Property RunStandbyServiceList As List(Of RunStandbyService)
        Get
            Return If(mcolRunStandbyServiceList, New List(Of RunStandbyService))
        End Get
    End Property

    Public Shared Function ServiceIsRunStandbyService(serviceId As String) As Boolean
        If String.IsNullOrWhiteSpace(serviceId) OrElse serviceId.Contains(",") Then
            ' Only applicable when a single service ID is passed.  
            Return False
        End If
        Return RunStandbyServiceList().Any(Function(s) StringsAreEqual(s.ServiceId, serviceId))
    End Function

    Public Shared Function GetCalculatedTimeIsStandbyFlag(serviceId As String) As Boolean
        Dim loService = RunStandbyServiceList().FirstOrDefault(Function(s) StringsAreEqual(s.ServiceId, serviceId))
        Return If(loService?.CalculatedTimeIsStandby, False)
    End Function

    Private Shared mcolSecLcMaterialList As List(Of GetListResult)
    Public Shared Async Function GetSecLcMaterialList() As Task(Of List(Of GetListResult))
        Try
            If mcolSecLcMaterialList Is Nothing Then
                mcolSecLcMaterialList = Await moLookupDataManager.GetSecLcMaterialListAsync()
                If mcolSecLcMaterialList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolSecLcMaterialList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetSecLcMaterialList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolSecurityList As List(Of GetListResult)
    Public Shared Async Function GetSecurityList() As Task(Of List(Of GetListResult))
        Try
            If mcolSecurityList Is Nothing Then
                mcolSecurityList = Await moLookupDataManager.GetSecurityListAsync()
                If mcolSecurityList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolSecurityList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetSecurityList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolServiceList As List(Of GetDispatchServiceListResult)
    Public Shared Async Function GetServiceList() As Task(Of List(Of GetDispatchServiceListResult))
        Try
            If mcolServiceList Is Nothing Then
                mcolServiceList = Await moLookupDataManager.GetDispServiceListAsync()
                If mcolServiceList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolServiceList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetServiceList", True)
        End Try
        Return New List(Of GetDispatchServiceListResult)
    End Function

    Public Shared ReadOnly Property ServiceList As List(Of GetDispatchServiceListResult)
        Get
            Return If(mcolServiceList, New List(Of GetDispatchServiceListResult))
        End Get
    End Property

    Private Shared mcolServiceTypeList As List(Of GetListResult)
    Public Shared Async Function GetServiceTypeList() As Task(Of List(Of GetListResult))
        Try
            If mcolServiceTypeList Is Nothing Then
                mcolServiceTypeList = Await moLookupDataManager.GetServiceTypeListAsync()
                If mcolServiceTypeList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolServiceTypeList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetServiceTypeList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolStatusList As List(Of GetStatusListResult)
    Public Shared Async Function GetStatusList() As Task(Of List(Of GetStatusListResult))
        Try
            If mcolStatusList Is Nothing Then
                mcolStatusList = Await moLookupDataManager.GetStatusListAsync()
                If mcolStatusList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolStatusList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetStatusList", True)
        End Try
        Return New List(Of GetStatusListResult)
    End Function

    Public Shared ReadOnly Property StatusList As List(Of GetStatusListResult)
        Get
            Return If(mcolStatusList, New List(Of GetStatusListResult))
        End Get
    End Property

    Public Shared Async Function GetStatusDescription(statusId As Short) As Task(Of String)
        Try
            Dim loStatus = Await GetStatus(statusId)
            If loStatus Is Nothing Then
                Exit Try
            End If

            Return loStatus.descrip
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetStatusDescription", True)
        End Try
        Return ""
    End Function

    Public Shared Async Function GetStatus(statusId As Short) As Task(Of GetStatusListResult)
        Try
            Return (Await GetStatusList()).FirstOrDefault(Function(s) s.status = statusId)
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData - GetStatus", True)
        End Try
        Return Nothing
    End Function

    Private Shared mcolTemperatureList As List(Of GetListResult)
    Public Shared Async Function GetTemperatureList() As Task(Of List(Of GetListResult))
        Try
            If mcolTemperatureList Is Nothing Then
                mcolTemperatureList = Await moLookupDataManager.GetTemperatureListAsync()
                If mcolTemperatureList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolTemperatureList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetTemperatureList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolTerritoryList As List(Of GetListResult)
    Public Shared Async Function GetTerritoryList() As Task(Of List(Of GetListResult))
        Try
            If mcolTerritoryList Is Nothing Then
                mcolTerritoryList = Await moLookupDataManager.GetTerritoryListAsync()
                If mcolTerritoryList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolTerritoryList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetTerritoryList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Public Shared ReadOnly Property TerritoryList As List(Of GetListResult)
        Get
            Return If(mcolTerritoryList, New List(Of GetListResult))
        End Get
    End Property

    Private Shared mcolTopConnectionList As List(Of GetListResult)
    Public Shared Async Function GetTopConnectionList() As Task(Of List(Of GetListResult))
        Try
            If mcolTopConnectionList Is Nothing Then
                mcolTopConnectionList = Await moLookupDataManager.GetTopConnectionListAsync()
                If mcolTopConnectionList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolTopConnectionList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetTopConnectionList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolTubularTypeList As List(Of GetListResult)
    Public Shared Async Function GetTubularTypeList() As Task(Of List(Of GetListResult))
        Try
            If mcolTubularTypeList Is Nothing Then
                mcolTubularTypeList = Await moLookupDataManager.GetTubularTypeListAsync()
                If mcolTubularTypeList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolTubularTypeList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetTubularTypeList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolWeightList As List(Of GetListResult)
    Public Shared Async Function GetWeightList() As Task(Of List(Of GetListResult))
        Try
            If mcolWeightList Is Nothing Then
                mcolWeightList = Await moLookupDataManager.GetWeightListAsync()
                If mcolWeightList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolWeightList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetWeightList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Private Shared mcolWellTypeList As List(Of GetListResult)
    Public Shared Async Function GetWellTypeList() As Task(Of List(Of GetListResult))
        Try
            If mcolWellTypeList Is Nothing Then
                mcolWellTypeList = Await moLookupDataManager.GetWellTypeListAsync()
                If mcolWellTypeList Is Nothing Then
                    Exit Try
                End If
            End If
            Return mcolWellTypeList
        Catch ex As Exception
            GlobalExceptionHandler.Log(ex, "GlobalData-GetWellTypeList", True)
        End Try
        Return New List(Of GetListResult)
    End Function

    Public Shared Sub ClearLoadedLists()
        mcolAcquisitionList = Nothing
        mcolAssetPmPtCalcTriggerFields = Nothing
        mcolBlindRamsList = Nothing
        mcolChargeCaseList = Nothing
        mcolChargeTypeList = Nothing
        mcolConcentrationList = Nothing
        mcolCountyList = Nothing
        mcolCurrencyList = Nothing
        mcolCustomerList = Nothing
        mcolDensityList = Nothing
        mcolDepthList = Nothing
        mcolDispConfigSectionList = Nothing
        mcolDistanceList = Nothing
        mcolDistrictList = Nothing
        mcolDrillerLevelList = Nothing
        mcolEnvironmentList = Nothing
        mcolExplosiveTypeList = Nothing
        mcolFluidInfoSourceList = Nothing
        mcolFluidSourceList = Nothing
        mcolFluidTypeList = Nothing
        mcolGunSizeList = Nothing
        mcolGunTypeList = Nothing
        mcolHoleSizeList = Nothing
        mcolInstrProtectionList = Nothing
        mcolLengthList = Nothing
        mcolOperationList = Nothing
        mcolPerfIntervalPolarityList = Nothing
        mcolPlantList = Nothing
        mcolPriceScheduleList = Nothing
        mcolProspectList = Nothing
        mcolProvinceList = Nothing
        mcolPslList = Nothing
        mcolRhaList = Nothing
        mcolRigList = Nothing
        mcolRigTypeList = Nothing
        mcolRunStandbyServiceList = Nothing
        mcolSecLcMaterialList = Nothing
        mcolSecurityList = Nothing
        mcolServiceList = Nothing
        mcolServiceTypeList = Nothing
        mcolStatusList = Nothing
        mcolTemperatureList = Nothing
        mcolTerritoryList = Nothing
        mcolTopConnectionList = Nothing
        mcolTubularTypeList = Nothing
        mcolWeightList = Nothing
        mcolWellTypeList = Nothing
    End Sub

    Public Shared Async Function FormattedDispId(pslId As String, dispId As Integer) As Task(Of String)
        Return Await GetPslVisualId(pslId) & Format(dispId, "000000")
    End Function

    Public Class ProvinceListItem
        Property province As String
    End Class
End Class
