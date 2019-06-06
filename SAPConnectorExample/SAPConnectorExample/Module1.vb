Imports SAP.Middleware.Connector

Module Module1

    Sub Main()
        Try
            ' SAP-System definieren (siehe auch App.config)
            ' PST Produktivsystem
            ' QST Testsystem
            ' TRT Entwicklungssystem
            Dim destination As RfcDestination
            destination = RfcDestinationManager.GetDestination("TRT")

            ' Name des Bausteins
            Dim rfcFunction As IRfcFunction = destination.Repository.CreateFunction("ZPP_WF_L_VERPACKUNG_TEST")

            ' Import-Parameter setzen
            rfcFunction.SetValue("IV_SERNR", "100000000000000000")

            ' Baustein aufrufen
            rfcFunction.Invoke(destination)

            ' Export-Parameter holen
            Dim EV_TIMESTAMP As String = rfcFunction.GetValue("EV_MENGE")
        Catch ex As Exception
            Console.WriteLine(ex.ToString())
        End Try
    End Sub

End Module
