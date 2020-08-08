Imports Inventor

Public Class Form1
    Dim internalDiameter, externalDiameter, height, fascia As Double ' nominal / input reference
    Dim externalDiameter1, externalDiameter2 As Double
    Dim dimensionA, dimensionB, dimensionC, dimensionD, dimensionE, dimensionG, dimensionH, dimensionEqual As Double
    Dim fasciaCollaudo1, fasciaCollaudo2 As Double

    Dim rodSplit1, rodSplit2, pisEndless As Boolean
    Dim splitType As String

    Dim drawingNumber As String

    Dim partDoc As Inventor.PartDocument
    Dim param As Inventor.Parameter
    Dim invApp As Inventor.Application = GetObject(, "Inventor.Application")

    ' Endless/Split-1/Split-2 Boolean'
    Public Sub radiobutton_rodSplit1_Click(sender As Object, e As EventArgs) Handles radiobutton_rodSplit1.Click
        If radiobutton_rodSplit1.Checked = True Then
            rodSplit1 = True
            splitType = "SINGOLO SPLIT"
        End If
    End Sub
    Public Sub radiobutton_rodSplit2_Click(sender As Object, e As EventArgs) Handles radiobutton_rodSplit2.Click
        If radiobutton_rodSplit2.Checked = True Then
            rodSplit2 = True
            splitType = "DOPPIO SPLIT"
        End If
    End Sub

    Public Sub radiobutton_pisEndless_Click(sender As Object, e As EventArgs) Handles radiobutton_pisEndless.Click
        If radiobutton_pisEndless.Checked = True Then
            pisEndless = True
            splitType = "ENDLESS"
        End If
    End Sub

    Public Sub SaveAsJPG(oPath As String, oWidth As Integer)
        Dim oDoc As DrawingDocument = invApp.ActiveDocument
        Dim oSheet As Sheet = oDoc.ActiveSheet
        Dim oView As Inventor.View = invApp.ActiveView
        Dim dAspectRatio As Double = oSheet.Height / oSheet.Width

       ' Adjust the aspect ratio of the view to match that of the sheet
       oView.height = oView.Width * dAspectRatio
       Dim oCamera As Camera = oView.Camera

       ' Center the sheet to the view
       oCamera.Fit

       ' Zoom to fit the sheet exactly within the view
       ' Add some tolerance to make sure the sheet borders are contained
       oCamera.SetExtents(oSheet.Width * 1.003, oSheet.Height * 1.003)

       ' Apply changes to the camera
       oCamera.Apply

       ' Save view to jpg. Make sure that the aspect ratio is maintained when exporting
       oView.SaveAsBitmap(oPath, oWidth, oWidth * dAspectRatio)

       ' Restore the view
       oCamera.Fit
       oCamera.Apply
       'oView.WindowState = kMaximize
       End Sub

    Public Sub button_ok_Click(sender As Object, e As EventArgs) Handles button_ok.Click
        ' Get the values from textbox and store as variable (Double)'
        internalDiameter = textbox_internalDiameter.Text
        externalDiameter = textbox_externalDiameter.Text
        height = textbox_height.Text
        drawingNumber = textbox_drawingNumber.Text

        Dim fascia As Double = (externalDiameter - internalDiameter) * 0.5

        ' Filtering the wrong values
        If internalDiameter > externalDiameter Then
            MessageBox.Show("Internal Diameter must be smaller than external diameter!", "Wrong Dimension", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If

        If internalDiameter + 7 >= externalDiameter Then
            MessageBox.Show("Cross section is too small!", "Wrong Dimension", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If

        If Height > 60 Then
            MessageBox.Show("Isn't the height too high?" & vbCrLf & "Lower the height and insert a backup ring.", "Wrong Dimension", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
        End If

        If height < fascia + 5 Then
            MessageBox.Show("The height is too low. Make it higher than " & fascia + 5 & " mm.", "Wrong dimension", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Me.Close()
        End If

        If internalDiameter > 2100 Or externalDiameter > 2100 Then
            MessageBox.Show("Isn't the diameter too big? Contact ufficio tecnico.", "Troppo grande", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
        End If

        ' HERE

        ' Open the part.'
        invApp.Documents.Open("C:\Test\Template\self-aligning-ring-1.ipt")

        ' Get the active document. This assums it's a part document.
        partDoc = invApp.ActiveDocument

        ' Get the Parameters collection.
        Dim params As Inventor.Parameters
        params = partDoc.ComponentDefinition.Parameters

        'SELF-ALIGNING RING 1
        ' Get the parameter named "dimensionH_parameter"'
        Dim oDimensionHParam As Inventor.Parameter
        oDimensionHParam = params.Item("dimensionH_parameter")

        ' Get the parameter named "fasciaCollaudo1_parameter"'
        Dim oFasciaCollaudo1Param As Inventor.Parameter
        oFasciaCollaudo1Param = params.Item("fasciaCollaudo1_parameter")

        ' Get the parameter named "dimensionE_parameter"'
        Dim oDimensionEParam As Inventor.Parameter
        oDimensionEParam = params.Item("dimensionE_parameter")

        ' Get the parameter named "externalDiameter1_parameter"'
        Dim oExternalDiameter1Param As Inventor.Parameter
        oExternalDiameter1Param = params.Item("externalDiameter1_parameter")

        ' Calculation parameters
        Dim dimensionAPre, dimensionDPre, dimensionHPre, fasciaCollaudo1Pre, fasciaCollaudo2Pre, externalDiameter1Pre As Double

        dimensionAPre = fascia * 0.03
        dimensionA = Math.Round([dimensionAPre], 1)

        dimensionEqual = (fascia * 0.5) - dimensionA
        dimensionB = fascia * 0.044
        dimensionG = fascia * 0.01
        dimensionC = fascia - dimensionG

        dimensionHPre = dimensionC - (dimensionEqual * 2) - dimensionA
        dimensionH = Math.Round([dimensionHPre], 1)

        dimensionDPre = fascia * 0.86
        dimensionD = Math.Round(dimensionDPre, 1)
        dimensionE = height

        fasciaCollaudo1Pre = fascia - dimensionB - dimensionG
        fasciaCollaudo2Pre = dimensionEqual + dimensionA
        fasciaCollaudo1 = Math.Round([fasciaCollaudo1Pre], 1)
        fasciaCollaudo2 = Math.Round([fasciaCollaudo2Pre], 1)

        externalDiameter1Pre = externalDiameter - (fascia * 0.088)
        externalDiameter1 = Math.Round([externalDiameter1Pre], 1)
        externalDiameter2 = externalDiameter

        ' Apply extra 1mm on diameter in case of 1-split / 2-splits.
        If rodSplit1 = True Or rodSplit2 = True Then
            externalDiameter1 = externalDiameter1 + 1
            externalDiameter2 = externalDiameter2 + 1
        End If

        ' TOLERANCE SETTING
        ' Fascia
        Dim finalToleranceFascia1, finalToleranceDimensionE As Double
        If fasciaCollaudo1 < 15 Then
            Call oFasciaCollaudo1Param.Tolerance.SetToSymmetric("0.1 mm")
            finalToleranceFascia1 = 0.1
        Else
            Call oFasciaCollaudo1Param.Tolerance.SetToSymmetric("0.15 mm")
            finalToleranceFascia1 = 0.15
        End If

        ' Height ( = dimension E)
        If dimensionE < 15 Then
            Call oDimensionEParam.Tolerance.SetToSymmetric("0.1 mm")
            finalToleranceDimensionE = 0.1
        Else
            Call oDimensionEParam.Tolerance.SetToSymmetric("0.15 mm")
            finalToleranceDimensionE = 0.15
        End If

        ' TOLERANCE External Diameter
        ' DOUBLE SPLIT
        Dim rodSplit As Boolean
        If rodSplit1 = True Or rodSplit2 Then
            rodSplit = True
        End If

        If rodSplit = True And externalDiameter < 1100 Then
            Call oExternalDiameter1Param.Tolerance.SetToDeviation("1.0 mm", "-0.0 mm")
        End If
        If rodSplit = True And externalDiameter >= 1100 Then
            Dim splitToleranceExternalDiameter As Double = externalDiameter * 0.0001
            Call oExternalDiameter1Param.Tolerance.SetToDeviation(Math.Round([splitToleranceExternalDiameter], 2), "-0,0 mm")  ' standard unit is cm, thus apply extra 0.1
        End If

        'Final tolerance on external diameter (in case of split)
        Dim finalTolerancePositive As Double = externalDiameter1 * 0.0005

        If externalDiameter1 < 2000 Then
            finalTolerancePositive = Math.Round(finalTolerancePositive, 1)
        Else
            finalTolerancePositive = 1
        End If

        ' Change the equation of the parameter.
        oDimensionHParam.Expression = dimensionH
        oFasciaCollaudo1Param.Expression = fasciaCollaudo1
        oDimensionEParam.Expression = dimensionE
        oExternalDiameter1Param.Expression = externalDiameter1

        ' Controlling iProperties part
        ' Get the "Design Tracking Properties" property set.
        Dim designTrackPropSet As Inventor.PropertySet
        designTrackPropSet = partDoc.PropertySets.Item("Design Tracking Properties")

        ' Assign "Drawing N°".
        ' Get the "Description" property from the property set.
        Dim descProp As Inventor.Property
        descProp = designTrackPropSet.Item("Description")
        ' Set the value of the property using the current value of the textbox.
        If checkBox_thirdParty.Checked = True Then
            descProp.Value =""
        Else
            descProp.Value = textbox_object.Text
        End If

        ' Assign "Material"
        ' Get the "Material" property from the property set
        Dim materialType As Inventor.Property
        materialType = designTrackPropSet.Item("Material")
        ' Set the value of the property using the value from input form
        materialType.Value = comboBox_materialType.Text

        ' Assign "Description (Endless/Double splits)".
        ' Get the "Project" property from the property set.
        Dim splitProp As Inventor.Property
        splitProp = designTrackPropSet.Item("Project")
        ' Set the value of the property using the current value of the textbox.
        If rodSplit1 = True Then
            splitProp.Value = "Self-aligning female ring-1 (1 split)"
        End If
        If rodSplit2 = True Then
            splitProp.Value = "Self-aligning female ring-1 (2 splits)"
        End If
        If pisEndless = True Then
            splitProp.Value = "Self-aligning female ring-1 (Endless)"
        End If

        ' Assign "Housing dimension".
        ' Get the "Inventor Summary Information" property set.
        Dim inventorSummaryInfoPropSet As Inventor.PropertySet
        inventorSummaryInfoPropSet = partDoc.PropertySets.Item("Inventor Summary Information")
        ' Get the "Subject" property from the property set.
        Dim housingProp As Inventor.Property
        housingProp = inventorSummaryInfoPropSet.Item("Subject")
        ' Set the value of the property using the current value of the textbox.
        If checkBox_thirdParty.Checked = True Then
            housingProp.Value = ""
        Else
            housingProp.Value = internalDiameter.ToString() & "/" & textbox_externalDiameter.Text.ToString() & " * " & textbox_housingHeight.Text.ToString() & " mm"
        End If

        ' Update the document.
        invApp.ActiveDocument.Update()

        ' Add revision N° in each exported file name (Except Rev.0)
        Dim revision As String
        If comboBox_revision.Text = "0" Or comboBox_revision.Text = "" Then
            revision = ""
        Else
            revision = "_rev." & comboBox_revision.Text
        End If

        ' Save the part-document with the assigned name (drawingNumber).
        invApp.ActiveDocument.SaveAs("C:\Test\" & drawingNumber & "-1" & revision & ".ipt", False)

        ' Replace the reference .ipt file on the drawing.
        Dim oDoc As Inventor.DrawingDocument
        oDoc = invApp.Documents.Open("C:\Test\Template\self-aligning-ring-1.idw")
        oDoc.File.ReferencedFileDescriptors(1).ReplaceReference("C:\Test\" & drawingNumber & "-1" & revision & ".ipt")

        ' Scale the drawing views according to the external diameter.
        ' View A
        Dim oViewA As DrawingView
        oViewA = oDoc.ActiveSheet.DrawingViews.Item(1)
        If textbox_externalDiameter.Text < 100 Then
            oViewA.[Scale] = 0.8
        ElseIf textbox_externalDiameter.Text >= 100 And textbox_externalDiameter.Text < 150 Then
            oViewA.[Scale] = 0.7
        ElseIf textbox_externalDiameter.Text >= 150 And textbox_externalDiameter.Text < 200 Then
            oViewA.[Scale] = 0.65
        ElseIf textbox_externalDiameter.Text >= 200 And textbox_externalDiameter.Text < 250 Then
            oViewA.[Scale] = 0.6
        ElseIf textbox_externalDiameter.Text >= 250 And textbox_externalDiameter.Text < 300 Then
            oViewA.[Scale] = 0.55
        ElseIf textbox_externalDiameter.Text >= 300 And textbox_externalDiameter.Text < 350 Then
            oViewA.[Scale] = 0.45
        ElseIf textbox_externalDiameter.Text >= 350 And textbox_externalDiameter.Text < 400 Then
            oViewA.[Scale] = 0.4
        ElseIf textbox_externalDiameter.Text >= 400 And textbox_externalDiameter.Text < 450 Then
            oViewA.[Scale] = 0.35
        ElseIf textbox_externalDiameter.Text >= 450 And textbox_externalDiameter.Text < 500 Then
            oViewA.[Scale] = 0.3
        ElseIf textbox_externalDiameter.Text >= 500 And textbox_externalDiameter.Text < 550 Then
            oViewA.[Scale] = 0.25
        ElseIf textbox_externalDiameter.Text >= 550 And textbox_externalDiameter.Text < 600 Then
            oViewA.[Scale] = 0.4
        ElseIf textbox_externalDiameter.Text >= 600 And textbox_externalDiameter.Text < 650 Then
            oViewA.[Scale] = 0.35
        ElseIf textbox_externalDiameter.Text >= 650 And textbox_externalDiameter.Text < 700 Then
            oViewA.[Scale] = 0.3
        ElseIf textbox_externalDiameter.Text >= 700 And textbox_externalDiameter.Text < 750 Then
            oViewA.[Scale] = 0.25
        ElseIf textbox_externalDiameter.Text >= 750 And textbox_externalDiameter.Text < 800 Then
            oViewA.[Scale] = 0.2
        ElseIf textbox_externalDiameter.Text >= 800 And textbox_externalDiameter.Text < 850 Then
            oViewA.[Scale] = 0.15
        ElseIf textbox_externalDiameter.Text >= 850 And textbox_externalDiameter.Text < 900 Then
            oViewA.[Scale] = 0.1
        ElseIf textbox_externalDiameter.Text >= 900 And textbox_externalDiameter.Text < 950 Then
            oViewA.[Scale] = 0.45
        ElseIf textbox_externalDiameter.Text >= 950 And textbox_externalDiameter.Text < 1000 Then
            oViewA.[Scale] = 0.4
        ElseIf textbox_externalDiameter.Text >= 1000 And textbox_externalDiameter.Text < 1050 Then
            oViewA.[Scale] = 0.35
        ElseIf textbox_externalDiameter.Text >= 1050 And textbox_externalDiameter.Text < 1100 Then
            oViewA.[Scale] = 0.3
        ElseIf textbox_externalDiameter.Text >= 1100 And textbox_externalDiameter.Text < 1150 Then
            oViewA.[Scale] = 0.25
        ElseIf textbox_externalDiameter.Text >= 1150 And textbox_externalDiameter.Text < 1200 Then
            oViewA.[Scale] = 0.2
        ElseIf textbox_externalDiameter.Text >= 1200 And textbox_externalDiameter.Text < 1250 Then
            oViewA.[Scale] = 0.15
        ElseIf textbox_externalDiameter.Text >= 1250 And textbox_externalDiameter.Text < 1300 Then
            oViewA.[Scale] = 0.1
        Else
            oViewA.[Scale] = 0.05
        End If

        ' Detail view "B"
        Dim oViewB As DetailDrawingView
        For Each oSheet As Sheet In oDoc.Sheets
            For Each oView As DrawingView In oSheet.DrawingViews
                If oView.ViewType = DrawingViewTypeEnum.kDetailDrawingViewType Then
                    oViewB = oView
                End If
            Next
        Next

        ' Set the scale of Detail View B depending on the size
        ' Scale the detail drawing view according to the height.
        If textbox_height.Text < 5 Then
            oViewB.[Scale] = 3
        ElseIf textbox_height.Text >= 5 And textbox_height.Text < 20 Then
            oViewB.[Scale] = 2.5
        ElseIf textbox_height.Text >= 20 And textbox_height.Text < 35 Then
            oViewB.[Scale] = 2
        Else
            oViewB.[Scale] = 1.5
        End If

        ' 3D view "View3D"
        Dim oView3D As DrawingView
        For Each oSheet As Sheet In oDoc.Sheets
            For Each oView As DrawingView In oSheet.DrawingViews
                If oView.ViewType = DrawingViewTypeEnum.kProjectedDrawingViewType Then
                    oView3D = oView
                End If
            Next
        Next

        ' Set the scale of 3D view depending on the size
        ' Scale the detail drawing view according to the height.
        If textbox_externalDiameter.Text < 100 Then
            oView3D.[Scale] = 0.4
        ElseIf textbox_externalDiameter.Text >= 100 And textbox_externalDiameter.Text < 200 Then
            oView3D.[Scale] = 0.2
        ElseIf textbox_externalDiameter.Text >= 200 And textbox_externalDiameter.Text < 400 Then
            oView3D.[Scale] = 0.15
        ElseIf textbox_externalDiameter.Text >= 400 And textbox_externalDiameter.Text < 700 Then
            oView3D.[Scale] = 0.1
        ElseIf textbox_externalDiameter.Text >= 700 And textbox_externalDiameter.Text < 1000 Then
            oView3D.[Scale] = 0.05
        ElseIf textbox_externalDiameter.Text >= 1000 And textbox_externalDiameter.Text < 1200 Then
            oView3D.[Scale] = 0.04
        Else
            oView3D.[Scale] = 0.03
        End If

        ' Update the revision table
        Dim oRevisionTable As RevisionTable = oDoc.ActiveSheet.RevisionTables.Item(1)
        Dim oRow As RevisionTableRow = oRevisionTable.RevisionTableRows.Item(1)
        Dim oCell1 As RevisionTableCell = oRow.Item(1)
        Dim oCell2 As RevisionTableCell = oRow.Item(2)
        Dim oCell3 As RevisionTableCell = oRow.Item(3)
        Dim oCell4 As RevisionTableCell = oRow.Item(4)
        Dim oCell5 As RevisionTableCell = oRow.Item(5)

        ' Date
        Dim oggi As Date = Date.Today   

        If comboBox_revision.Text = "0" Or comboBox_revision.Text = "" Then
            oCell1.Text = "0"
        Else
            oCell1.Text = comboBox_revision.Text    ' Revision N°
        End If

        If oCell1.Text = "0" Or oCell1.Text = "" Then                    ' Description (If Revision N° is "0", assign "Drawing Issue"
            oCell2.Text = "Drawing Issue"
        Else
            oCell2.Text = textbox_description.Text
        End If
        oCell3.Text = "Automated"               ' Drawn
        oCell4.Text = textbox_signature.Text    ' Approved
        oCell5.Text = oggi                      ' Date (dd/mm/yyyy)

        ' Created a textbox to indicate final dimensions
        Dim oSketch As DrawingSketch
        oSketch = oDoc.ActiveSheet.Sketches.Add
        oSketch.Edit

        Dim oTG As TransientGeometry
        oTG = invApp.TransientGeometry

        ' Create 3 lines of final dimension with tolerance
        Dim o1TextBox1, o1TextBox2, o1TextBox3, o1TextBox4, o1TextBoxFin As TextBox
        o1TextBox1 = oSketch.TextBoxes.AddFitted(oTG.CreatePoint2D(2.5, 9.1), "Øext coll. = " & externalDiameter1 - 1 & " mm" & " +" & finalTolerancePositive & " / -" & 0 )
        o1TextBox2 = oSketch.TextBoxes.AddFitted(oTG.CreatePoint2D(2.5, 8.4), "F coll. = " & fasciaCollaudo1 & " mm" & " ±" & finalToleranceFascia1)
        o1TextBox3 = oSketch.TextBoxes.AddFitted(oTG.CreatePoint2D(2.5, 7.7), "H coll. = " & dimensionE & " mm" & " ±" & finalToleranceDimensionE)
        o1TextBox4 = oSketch.TextBoxes.AddFitted(oTG.CreatePoint2D(2.5, 7), splitType)

        o1TextBox1.Style.FontSize = 0.3
        o1TextBox2.Style.FontSize = 0.3
        o1TextBox3.Style.FontSize = 0.3
        o1TextBox4.Style.FontSize = 0.3

        ' Create a note of "Object" & "Housing dimension" in case the drawing is for a third party.
        If checkBox_thirdParty.Checked = True Then
        Dim o1TextBoxObject, o1TextBoxHousingDimension As TextBox
        o1TextBoxObject = oSketch.TextBoxes.AddFitted(oTG.CreatePoint2D(25, 3.5), textbox_object.Text )
        o1TextBoxHousingDimension = oSketch.TextBoxes.AddFitted(oTG.CreatePoint2D(25, 3), internalDiameter.ToString() & "/" & textbox_externalDiameter.Text.ToString() & " * " & textbox_housingHeight.Text.ToString() & " mm" )
        End If

        ' Exit the sketch mode from the edit environment
        oSketch.ExitEdit

        ' Save the drawing-document with the assigned name (drawingNumber).
        invApp.ActiveDocument.SaveAs("C:\Test\" & drawingNumber & "-1" & revision & ".idw", False)

        ' Update the document.'
        invApp.ActiveDocument.Update()

        ' Export to PDF.'
        ' Get the active docuement.
        oDoc = invApp.ActiveDocument

        ' Save a copy as a PDF file.
        Call oDoc.SaveAs("C:\Test\" & drawingNumber & "-1" & revision & ".pdf", True)

        ' Save a copy as a jpeg file.
        ' Call oDoc.SaveAs("\\dataserver2019\Tecnici\CARCO\DISEGNI\TORNITURA+MODIFICHE\" + drawingNumber + ".jpg", True)

        Call SaveAsJPG("C:\Test\Images\" & drawingNumber & "-1" & revision & ".jpg", 2303)
        
        ' CREATE A PART FOR THE RING - 2
        ' Open the part.'
        invApp.Documents.Open("C:\Test\Template\self-aligning-ring-2.ipt")

        ' Get the active document. This assums it's a part document.
        partDoc = invApp.ActiveDocument

        ' Get the Parameters collection.
        ' Dim params As Inventor.Parameters
        params = partDoc.ComponentDefinition.Parameters

        ' Self-aligning ring 2
        ' Get the parameter named "dimensionA_parameter"
        Dim oDimensionAParam As Inventor.Parameter
        oDimensionAParam = params.Item("dimensionA_parameter")

        ' Get the parameter named "fasciaCollaudo2_parameter"
        Dim oFasciaCollaudo2Param As Inventor.Parameter
        oFasciaCollaudo2Param = params.Item("fasciaCollaudo2_parameter")

        ' Get the parameter named "dimensionD_parameter"
        Dim oDimensionDParam As Inventor.Parameter
        oDimensionDParam = params.Item("dimensionD_parameter")

        ' Get the parameter named "externalDiameter2_parameter"
        Dim oExternalDiameter2Param As Inventor.Parameter
        oExternalDiameter2Param = params.Item("externalDiameter2_parameter")

        ' TOLERANCE SETTING
        ' Fascia
        Dim finalToleranceFascia2, finalToleranceDimensionD As Double
        If fasciaCollaudo2 < 15 Then
            Call oFasciaCollaudo2Param.Tolerance.SetToSymmetric("0.1 mm")
            finalToleranceFascia2 = 0.1
        Else
            Call oFasciaCollaudo2Param.Tolerance.SetToSymmetric("0.15 mm")
            finalToleranceFascia2 = 0.15
        End If

        ' Height ( = dimension D)
        If dimensionD < 15 Then
            Call oDimensionDParam.Tolerance.SetToSymmetric("0.1 mm")
            finalToleranceDimensionD = 0.1
        Else
            Call oDimensionDParam.Tolerance.SetToSymmetric("0.15 mm")
            finalToleranceDimensionD = 0.15
        End If

        If rodSplit = True And externalDiameter < 1100 Then
            Call oExternalDiameter2Param.Tolerance.SetToDeviation("1.0 mm", "-0.0 mm")
        End If
        If rodSplit = True And externalDiameter >= 1100 Then
            Dim splitToleranceExternalDiameter As Double = externalDiameter * 0.0001
            Call oExternalDiameter2Param.Tolerance.SetToDeviation(Math.Round([splitToleranceExternalDiameter], 2), "-0,0 mm")  ' standard unit is cm, thus apply extra 0.1
        End If

        ' TOLERANCE
        ' EXTERNAL DIMATER
        ' Final tolerance on external diameter (in case of split)

        ' Change the equation of the parameter.
        oDimensionAParam.Expression = dimensionA
        oFasciaCollaudo2Param.Expression = fasciaCollaudo2
        oDimensionDParam.Expression = dimensionD
        oExternalDiameter2Param.Expression = externalDiameter2

        ' Controlling iProperties part
        ' Get the "Design Tracking Properties" property set.
        Dim designTrackPropSet2 As Inventor.PropertySet
        designTrackPropSet2 = partDoc.PropertySets.Item("Design Tracking Properties")

        ' Assign "Drawing N°".
        ' Get the "Description" property from the property set.
        Dim descProp2 As Inventor.Property
        descProp2 = designTrackPropSet2.Item("Description")
        ' Set the value of the property using the current value of the textbox.
        If checkBox_thirdParty.Checked = True Then
        descProp2.Value = ""
        Else
        descProp2.Value = textbox_object.Text
        End If

        ' Assign "Material"
        ' Get the "Material" property from the property set.
        Dim materialType2 As Inventor.Property
        materialType2 = designTrackPropSet2.Item("Material")
        ' Set the value of the property using the value from input form
        materialType2.Value = comboBox_materialType.Text

        ' Assign "Description (Endless/Double splits)".
        ' Get the "Project" property from the property set.
        Dim splitProp2 As Inventor.Property
        splitProp2 = designTrackPropSet2.Item("Project")
        ' Set the value of the property using the current value of the textbox.
        If rodSplit1 = True Then
            splitProp2.Value = "Self-aligning female ring-2 (1 split)"
        End If
        If rodSplit2 = True Then
            splitProp2.Value = "Self-aligning female ring-2 (2 splits)"
        End If
        If pisEndless = True Then
            splitProp2.Value = "Self-aligning female ring-2 (Endless)"
        End If

        ' Assign "Housing dimension"
        ' Get the "Inventor Summary Information" property set.
        Dim inventorSummaryInfoPropSet2 As Inventor.PropertySet
        inventorSummaryInfoPropSet2 = partDoc.PropertySets.Item("Inventor Summary Information")
        ' Get the "Subject" property from the property set.
        Dim housingProp2 As Inventor.Property
        housingProp2 = inventorSummaryInfoPropSet2.Item("Subject")
        ' Set the value of the property using the current value of the textbox.
        If checkBox_thirdParty.Checked = True Then
        housingProp2.Value = ""
        Else
        housingProp2.Value = internalDiameter.ToString() & "/" & textbox_externalDiameter.Text.ToString() & " * " & textbox_housingHeight.Text.ToString() & " mm"
        End If

        ' Update the document.
        invApp.ActiveDocument.Update()

        ' Save the part-document with the assigned name (drawingNumber).
        invApp.ActiveDocument.SaveAs("C:\Test\" & drawingNumber & "-2" & revision & ".ipt", False)

        ' Replace the reference .ipt file on the drawing.
        Dim oDoc2 As Inventor.DrawingDocument
        oDoc2 = invApp.Documents.Open("C:\Test\Template\self-aligning-ring-2.idw")
        oDoc2.File.ReferencedFileDescriptors(1).ReplaceReference("C:\Test\" & drawingNumber & "-2" & revision & ".ipt")

        ' Scale the drawing views according to the external diameter.
        ' View A
        Dim oViewA2 As DrawingView
        oViewA2 = oDoc2.ActiveSheet.DrawingViews.Item(1)
        If textbox_externalDiameter.Text < 100 Then
            oViewA2.[Scale] = 0.8
        ElseIf textbox_externalDiameter.Text >= 100 And textbox_externalDiameter.Text < 150 Then
            oViewA2.[Scale] = 0.7
        ElseIf textbox_externalDiameter.Text >= 150 And textbox_externalDiameter.Text < 200 Then
            oViewA2.[Scale] = 0.65
        ElseIf textbox_externalDiameter.Text >= 200 And textbox_externalDiameter.Text < 250 Then
            oViewA2.[Scale] = 0.6
        ElseIf textbox_externalDiameter.Text >= 250 And textbox_externalDiameter.Text < 300 Then
            oViewA2.[Scale] = 0.55
        ElseIf textbox_externalDiameter.Text >= 300 And textbox_externalDiameter.Text < 350 Then
            oViewA2.[Scale] = 0.45
        ElseIf textbox_externalDiameter.Text >= 350 And textbox_externalDiameter.Text < 400 Then
            oViewA2.[Scale] = 0.4
        ElseIf textbox_externalDiameter.Text >= 400 And textbox_externalDiameter.Text < 450 Then
            oViewA2.[Scale] = 0.35
        ElseIf textbox_externalDiameter.Text >= 450 And textbox_externalDiameter.Text < 500 Then
            oViewA2.[Scale] = 0.3
        ElseIf textbox_externalDiameter.Text >= 500 And textbox_externalDiameter.Text < 550 Then
            oViewA2.[Scale] = 0.25
        ElseIf textbox_externalDiameter.Text >= 550 And textbox_externalDiameter.Text < 600 Then
            oViewA2.[Scale] = 0.4
        ElseIf textbox_externalDiameter.Text >= 600 And textbox_externalDiameter.Text < 650 Then
            oViewA2.[Scale] = 0.375
        ElseIf textbox_externalDiameter.Text >= 650 And textbox_externalDiameter.Text < 700 Then
            oViewA2.[Scale] = 0.35
        ElseIf textbox_externalDiameter.Text >= 700 And textbox_externalDiameter.Text < 750 Then
            oViewA2.[Scale] = 0.25
        ElseIf textbox_externalDiameter.Text >= 750 And textbox_externalDiameter.Text < 800 Then
            oViewA2.[Scale] = 0.2
        ElseIf textbox_externalDiameter.Text >= 800 And textbox_externalDiameter.Text < 850 Then
            oViewA2.[Scale] = 0.15
        ElseIf textbox_externalDiameter.Text >= 850 And textbox_externalDiameter.Text < 900 Then
            oViewA2.[Scale] = 0.1
        ElseIf textbox_externalDiameter.Text >= 900 And textbox_externalDiameter.Text < 950 Then
            oViewA2.[Scale] = 0.45
        ElseIf textbox_externalDiameter.Text >= 950 And textbox_externalDiameter.Text < 1000 Then
            oViewA2.[Scale] = 0.4
        ElseIf textbox_externalDiameter.Text >= 1000 And textbox_externalDiameter.Text < 1050 Then
            oViewA2.[Scale] = 0.35
        ElseIf textbox_externalDiameter.Text >= 1050 And textbox_externalDiameter.Text < 1100 Then
            oViewA2.[Scale] = 0.3
        ElseIf textbox_externalDiameter.Text >= 1100 And textbox_externalDiameter.Text < 1150 Then
            oViewA2.[Scale] = 0.25
        ElseIf textbox_externalDiameter.Text >= 1150 And textbox_externalDiameter.Text < 1200 Then
            oViewA2.[Scale] = 0.2
        ElseIf textbox_externalDiameter.Text >= 1200 And textbox_externalDiameter.Text < 1250 Then
            oViewA2.[Scale] = 0.15
        ElseIf textbox_externalDiameter.Text >= 1250 And textbox_externalDiameter.Text < 1300 Then
            oViewA2.[Scale] = 0.1
        Else
            oViewA2.[Scale] = 0.05
        End If

        ' Detail view "B".
        Dim oViewB2 As DetailDrawingView
        For Each oSheet2 As Sheet In oDoc2.Sheets
            For Each oView2 As DrawingView In oSheet2.DrawingViews
                If oView2.ViewType = DrawingViewTypeEnum.kDetailDrawingViewType Then
                    oViewB2 = oView2
                End If
            Next
        Next

        ' Set the scale of Detail View B depending on the size
        ' Scale the detail drawing view according to the height.
        If textbox_height.Text < 5 Then
            oViewB2.[Scale] = 3
        ElseIf textbox_height.Text >= 5 And textbox_height.Text < 20 Then
            oViewB2.[Scale] = 2.5
        ElseIf textbox_height.Text >= 20 And textbox_height.Text < 35 Then
            oViewB2.[Scale] = 2
        Else
            oViewB2.[Scale] = 1.5
        End If

        ' 3D view "View3D"
        Dim oView3D2 As DrawingView
        For Each oSheet2 As Sheet In oDoc2.Sheets
            For Each oView2 As DrawingView In oSheet2.DrawingViews
                If oView2.ViewType = DrawingViewTypeEnum.kProjectedDrawingViewType Then
                    oView3D2 = oView2
                End If
            Next
        Next

        ' Set the scale of 3D view depending on the size
        ' Scale the detail drawing view according to the height.
        If textbox_externalDiameter.Text < 100 Then
            oView3D2.[Scale] = 0.4
        ElseIf textbox_externalDiameter.Text >= 100 And textbox_externalDiameter.Text < 200 Then
            oView3D2.[Scale] = 0.2
        ElseIf textbox_externalDiameter.Text >= 200 And textbox_externalDiameter.Text < 400 Then
            oView3D2.[Scale] = 0.15
        ElseIf textbox_externalDiameter.Text >= 400 And textbox_externalDiameter.Text < 700 Then
            oView3D2.[Scale] = 0.1
        ElseIf textbox_externalDiameter.Text >= 700 And textbox_externalDiameter.Text < 1000 Then
            oView3D2.[Scale] = 0.05
        ElseIf textbox_externalDiameter.Text >= 1000 And textbox_externalDiameter.Text < 1200 Then
            oView3D2.[Scale] = 0.04
        Else
            oView3D2.[Scale] = 0.03
        End If

        ' Update the revision table
        Dim oRevisionTable2 As RevisionTable = oDoc2.ActiveSheet.RevisionTables.Item(1)
        Dim oRow2 As RevisionTableRow = oRevisionTable2.RevisionTableRows.Item(1)
        Dim o2Cell1 As RevisionTableCell = oRow2.Item(1)
        Dim o2Cell2 As RevisionTableCell = oRow2.Item(2)
        Dim o2Cell3 As RevisionTableCell = oRow2.Item(3)
        Dim o2Cell4 As RevisionTableCell = oRow2.Item(4)
        Dim o2Cell5 As RevisionTableCell = oRow2.Item(5)

        If comboBox_revision.Text = "0" Or comboBox_revision.Text = "" Then
            o2Cell1.Text = "0"
        Else
            o2Cell1.Text = comboBox_revision.Text    ' Revision N°
        End If

        If o2Cell1.Text = "0" Or oCell1.Text = "" Then                    ' Description (If Revision N° is "0", assign "Drawing Issue"
            o2Cell2.Text = "Drawing Issue"
        Else
            o2Cell2.Text = textbox_description.Text
        End If
        o2Cell3.Text = "Automated"               ' Drawn
        o2Cell4.Text = textbox_signature.Text    ' Approved
        o2Cell5.Text = oggi                      ' Date (dd/mm/yyyy)

        ' Created a textbox to indicate final dimensions
        Dim oSketch2 As DrawingSketch
        oSketch2 = oDoc2.ActiveSheet.Sketches.Add
        oSketch2.Edit

        Dim oTG2 As TransientGeometry
        oTG2 = invApp.TransientGeometry

        ' Create 3 lines of final dimension with tolerance
        Dim o2TextBox1, o2TextBox2, o2TextBox3, o2TextBox4 As TextBox
        o2TextBox1= oSketch2.TextBoxes.AddFitted(oTG2.CreatePoint2D(2.5, 9.1), "Øext coll. = " & externalDiameter2 - 1 & " mm" & " +" & 0 & " / -" & finalTolerancePositive )
        o2TextBox2 = oSketch2.TextBoxes.AddFitted(oTG2.CreatePoint2D(2.5, 8.4), "F coll. = " & fasciaCollaudo2 & " mm" & " ±" & finalToleranceFascia2)
        o2TextBox3 = oSketch2.TextBoxes.AddFitted(oTG2.CreatePoint2D(2.5, 7.7), "H coll. = " & dimensionD & " mm" & " ±" & finalToleranceDimensionE)
        o2TextBox4 = oSketch2.TextBoxes.AddFitted(oTG2.CreatePoint2D(2.5, 7), splitType)

        o2TextBox1.Style.FontSize = 0.3
        o2TextBox2.Style.FontSize = 0.3
        o2TextBox3.Style.FontSize = 0.3
        o2TextBox4.Style.FontSize = 0.3

        ' Create a note of "Object" & "Housing dimension" in case the drawing is for a third party.
        If checkBox_thirdParty.Checked = True Then
        Dim o2TextBoxObject, o2TextBoxHousingDimension As TextBox
        o2TextBoxObject = oSketch2.TextBoxes.AddFitted(oTG2.CreatePoint2D(25, 3.5), textbox_object.Text )
        o2TextBoxHousingDimension = oSketch2.TextBoxes.AddFitted(oTG2.CreatePoint2D(25, 3), internalDiameter.ToString() & "/" & textbox_externalDiameter.Text.ToString() & " * " & textbox_housingHeight.Text.ToString() & " mm" )
        End If

        ' Exit the sketch mode from the edit environment
        oSketch2.ExitEdit

        ' Save the drawing-document with the assigned name (drawingNumber).
        invApp.ActiveDocument.SaveAs("C:\Test\" & drawingNumber & "-2" & revision & ".idw", False)

        ' Update the document.
        invApp.ActiveDocument.Update()

        ' Export to PDF.
        ' Get the active docuement.
        oDoc2 = invApp.ActiveDocument

        ' Save a copy as a PDF file.
        Call oDoc2.SaveAs("C:\Test\" & drawingNumber & "-2" & revision & ".pdf", True)

        ' Save a copy as a jpg file.
        Call SaveAsJPG("C:\Test\Images\" & drawingNumber & "-2" & revision & ".jpg", 2303)

        ' Finishing message
        MessageBox.Show("Automated drawing is generated. Please double check!", "Taaaaaac! :D", MessageBoxButtons.OK, MessageBoxIcon.None)
        Me.Close()
    End Sub
End Class
