Public Class Form1
    Public unitCount As Integer
    Public feeEnrol As Single
    Public feePerUnit As Single
    Public feeTotalCalc As Single
    Public subjectCount As Integer
    Public Valid As Boolean


    'set up a record or "class" for a student
    Class STUDENT
        Public firstname As String
        Public lastname As String
        Public dateGrad As Date
        Public gender As String
        Public avMk As Single
        Public stYear As Integer
        Public subMath2U As Boolean
        Public subMathExt1U As Boolean
        Public subEng As Boolean
        Public subSci As Boolean
        Public subPho As Boolean
        Public feeTotalPaid As Single
        Public feePaid As Boolean

    End Class

    Dim students(9) As STUDENT
    Dim studentCount As Integer = 0
    Private Sub ValidateFirstName()
        If txtFirstName.Text = "" Then
            Valid = False

            MsgBox("Please enter a First Name", MsgBoxStyle.Critical, "First name Validation")
            txtFirstName.Focus()  'put cursor here

            Exit Sub
        End If
        If Len(txtFirstName.Text) > 30 Then
            MsgBox("Please shorten the First Name " & txtFirstName.Text & " " & Len(txtFirstName.Text), MsgBoxStyle.Critical, "First name Validation")
            txtFirstName.Focus()
            Valid = False
            Exit Sub
        End If
    End Sub
    Private Sub ValidateLastName()
        If txtLastName.Text = "" Then
            MsgBox("Please enter a Last Name", MsgBoxStyle.Critical, "Name validation")
            txtLastName.Focus()
            Valid = False
            Exit Sub
        End If
        If Len(txtLastName.Text) > 30 Then
            MsgBox("Please shorten the Last Name " & txtFirstName.Text & " " & Len(txtFirstName.Text), MsgBoxStyle.Critical, "Name validation")
            txtLastName.Focus()
            Valid = False
            Exit Sub
        End If
    End Sub
    Private Sub validateAverageMark()
        If Not IsNumeric(txtAvMk.Text) Then
            MsgBox("Please enter a decimal ", MsgBoxStyle.Critical, "Mark validation")
            txtAvMk.Focus()
            Valid = False
            Exit Sub
        End If

        If txtAvMk.Text = "" Then
            MsgBox("Please enter a mark", MsgBoxStyle.Critical, "Mark Validation")
            txtAvMk.Focus()
            Valid = False
            Exit Sub
        End If
        If txtAvMk.Text > 100 Then
            MsgBox("Please enter a number below 100", MsgBoxStyle.Critical, "Mark Validation")
            txtAvMk.Focus()
            Valid = False
            Exit Sub
        End If
        If txtAvMk.Text < 0 Then
            MsgBox("Please enter a mark between 1 and 100", MsgBoxStyle.Critical)
            txtAvMk.Focus()
            Valid = False
            Exit Sub
        End If
    End Sub
    Private Sub validateGender()
        If txtGender.Text = "" Then
            MsgBox("Please enter 'm' of 'f'!", MsgBoxStyle.Critical, "Gender validation")
            txtGender.Focus()
            Valid = False
            Exit Sub
        End If
        'Note the syntax necessary to make this work
        If Not (txtGender.Text = "m" Or txtGender.Text = "f" Or txtGender.Text = "M" Or txtGender.Text = "F") Then
            MsgBox("Please enter 'm' of 'f'!", MsgBoxStyle.Critical, "Gender Validation")
            txtGender.Focus()
            Valid = False
            Exit Sub
        End If

        'Alternative code from Johan
        ''''If txtGender.Text = "m" Then
        ''''ElseIf txtGender.Text = "M" Then
        ''''ElseIf txtGender.Text = "f" Then
        ''''ElseIf txtGender.Text = "F" Then
        ''''Else MsgBox("Please enter 'm' of 'f'!", MsgBoxStyle.Critical)
        ''''    txtGender.Focus()
        ''''    Exit Sub
        ''''End If
    End Sub
    Private Sub validateFeePaid()


        If Not txtFeeTotalPaid.Text = txtFeeTotalCalc.Text Then
            MsgBox("You have not paid the correct amount", MsgBoxStyle.Critical, "Paid amount validation")
            txtFeeTotalPaid.Focus()
            Valid = False
            Exit Sub
        End If
    End Sub

    Private Sub validateDate()
        If Not IsDate(dteGraduation.Text & " " & cboGradHr.Text & ":" & cboGradMin.Text) Then
            MsgBox("Please enter a date in the format 'dd/mm/yy' format!", MsgBoxStyle.Critical, "Date validation")
            dteGraduation.Focus()
            Valid = False
            Exit Sub
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'allocate memory
        For i = 0 To 9
            students(i) = New STUDENT
        Next
        'Load default unit values:
        txtUnitMath.Text = 2
        txtUnitMathExt.Text = 1
        txtUnitEng.Text = 2
        txtUnitSci.Text = 2
        txtUnitPho.Text = 1

        'set unit count to 0
        unitCount = 0
        feeEnrol = 1000
        feePerUnit = 50
        feeTotalCalc = 0
        txtUnitCountCalc.Text = unitCount
        txtFeeEnrol.Text = feeEnrol
        txtFeePerUnit.Text = feePerUnit


        'load 4 test records
        students(0).firstname = "Johnny"
        students(0).lastname = "Depp"
        students(0).dateGrad = "9/6/63 8:30"
        students(0).gender = "m"
        students(0).avMk = 78.2
        students(0).feeTotalPaid = 999
        students(1).firstname = "Jennifer"
        students(1).lastname = "Lawrence"
        students(1).dateGrad = "15/8/90 9:30"
        students(1).gender = "f"
        students(1).avMk = 88.2
        students(2).firstname = "George"
        students(2).lastname = "Clooney"
        students(2).dateGrad = "6/5/61 9:30"
        students(2).gender = "f"
        students(2).avMk = 68.2
        students(3).firstname = "Scarlett"
        students(3).lastname = "Johansson"
        students(3).dateGrad = "22/11/84 12:30"
        students(3).gender = "f"
        students(3).avMk = 72.2
        students(4).firstname = "Blackwattle"
        students(4).lastname = "Bay"
        students(4).dateGrad = "28/2/2000 9:45"
        students(4).gender = "m"
        students(4).avMk = 25
        'set the student count to the number of students which have been entered
        studentCount = 5    'be sure to change this if you add extras

        displayList()

    End Sub
    Private Sub btnAddStud_Click(sender As Object, e As EventArgs) Handles btnAddStud.Click
        Valid = True

        ValidateFirstName()
        If Valid = False Then
            txtFirstName.Focus()
            Exit Sub
        End If

        ValidateLastName()
        If Valid = False Then
            txtLastName.Focus()
            Exit Sub
        End If
        validateGender()
        If Valid = False Then
            txtGender.Focus()
            Exit Sub
        End If
        validateAverageMark()
        If Valid = False Then
            txtAvMk.Focus()
            Exit Sub
        End If

        validateDate()
        If Valid = False Then
            cboGradHr.Focus()
            Exit Sub
        End If

        If students(studentCount).stYear = 0 Then
            MsgBox("Please select a Year")
            Exit Sub
        End If

        If subjectCount > 3 Or subjectCount = 0 Then
            MsgBox("Please choose 1 to 3 subjects only!", MsgBoxStyle.Critical, "Subject number validation")
            chkSubjMaths2U.Focus()
            Exit Sub
        End If

        validateFeePaid()
        If Valid = False Then
            txtFeeTotalPaid.Focus()
            Exit Sub
        End If

        If students(studentCount).feePaid = False Then
            MsgBox("Please click the paid button!", MsgBoxStyle.Critical, "Fee Paid checked validation") 'This is to ensure they check the paid button
            chkPaid.Focus()
            Exit Sub
        End If



        'Checks if subjectTotal is only 3 or less'




        'place text from text boxes into the array - first students(0), then students(1), students(2) etc
        students(studentCount).firstname = txtFirstName.Text
        students(studentCount).lastname = txtLastName.Text
        students(studentCount).dateGrad = dteGraduation.Text & " " & cboGradHr.Text & ":" & cboGradMin.Text
        students(studentCount).gender = txtGender.Text
        students(studentCount).avMk = txtAvMk.Text
        students(studentCount).feeTotalPaid = txtFeeTotalPaid.Text


        studentCount = studentCount + 1

        'return text boxes to blank ready for next entry
        txtFirstName.Text = ""
        txtLastName.Text = ""
        dteGraduation.Text = ""
        txtGender.Text = ""
        txtAvMk.Text = ""
        txtFeeTotalPaid.Text = ""
        chkSubjEng2U.CheckState = CheckState.Unchecked
        students(studentCount).subEng = False
        chkPaid.CheckState = CheckState.Unchecked
        students(studentCount).feePaid = False
        chkSubjMaths2U.CheckState = CheckState.Unchecked
        students(studentCount).subMath2U = False

        chkSubjMathsExt1U.CheckState = CheckState.Unchecked
        students(studentCount).subMathExt1U = False

        chkSubjPho1U.CheckState = CheckState.Unchecked
        students(studentCount).subPho = False

        chkSubjSci2U.CheckState = CheckState.Unchecked
        students(studentCount).subSci = False
        students(studentCount).stYear = 0
        radYr10.Checked = False
        radYr11.Checked = False
        radYr12.Checked = False

        displayList()






    End Sub

    Private Sub displayList()

        'clear the list box as it keeps the earlier loop
        lstStud.Items.Clear()
        'loop through the array to print all rows
        For i = 0 To studentCount - 1
            lstStud.Items.Add(students(i).firstname & ", " & students(i).lastname & ", " & students(i).dateGrad & ", " & students(i).gender & ", " & students(i).avMk & ", Yr" & students(i).stYear & ", Sci " & students(i).subSci & "," & "Eng " & students(i).subEng & ", " & "Pho " & students(i).subPho & "," & "Maths2U " & students(i).subMath2U & ", " & "MathExt1 " & students(i).subMathExt1U & "," & " Fees paid " & students(i).feePaid & "," & " Total Fees Paid " & students(i).feeTotalPaid & ".")
        Next
    End Sub
    Private Sub calcUnitTotal()
        txtUnitCountCalc.Text = unitCount
        txtFeeTotalCalc.Text = feeEnrol + unitCount * feePerUnit

        txtSubTotal.Text = subjectCount
    End Sub

    Private Sub txtFirstName_TextChanged(sender As Object, e As EventArgs) Handles txtFirstName.Leave
        'VALIDATION of First Name
        ValidateFirstName()

    End Sub

    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.Leave
        'VALIDATION of Last Name
        ValidateLastName()

    End Sub

    Private Sub txtGender_TextChanged(sender As Object, e As EventArgs) Handles txtGender.Leave
        'VALIDATION of Gender
        validateGender()
    End Sub

    Private Sub txtAvMk_TextChanged(sender As Object, e As EventArgs) Handles txtAvMk.Leave
        'Average mark validation
        validateAverageMark()
    End Sub

    Private Sub dteGraduation_ValueChanged(sender As Object, e As EventArgs) Handles dteGraduation.ValueChanged
        'VALIDATION of Grad Date - not really necessary with a picker!!!
        If Not IsDate(dteGraduation.Text) Then
            MsgBox("Please enter a date in the format 'dd/mm/yy' format!", MsgBoxStyle.Critical, "Date validation")
            dteGraduation.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub chkSubjMaths2U_CheckedChanged(sender As Object, e As EventArgs) Handles chkSubjMaths2U.CheckedChanged

        If chkSubjMaths2U.Checked Then
            unitCount = unitCount + Convert.ToInt16(txtUnitMath.Text)
            subjectCount = subjectCount + 1

        Else
            unitCount = unitCount - Convert.ToInt16(txtUnitMath.Text)
            subjectCount = subjectCount - 1
        End If

        If subjectCount = 4 Then
            MsgBox("select 1 to 3 subjects only", MsgBoxStyle.Critical, "Subject Count Validation")
            students(studentCount).subMath2U = True
            chkSubjMaths2U.Checked = vbFalse
            Exit Sub

        End If

        If students(studentCount).subMath2U = True Then
            students(studentCount).subMath2U = False
        Else
            students(studentCount).subMath2U = True
        End If
        calcUnitTotal()
        chkSubjMaths2U.Focus()


    End Sub

    Private Sub chkSubjMathsExt1U_CheckedChanged(sender As Object, e As EventArgs) Handles chkSubjMathsExt1U.CheckedChanged
        If chkSubjMathsExt1U.Checked Then
            unitCount = unitCount + txtUnitMathExt.Text
            subjectCount = subjectCount + 1


        Else
            unitCount = unitCount - txtUnitMathExt.Text
            subjectCount = subjectCount - 1

        End If

        If subjectCount = 4 Then
            MsgBox("select 1 to 3 subjects only", MsgBoxStyle.Critical, "Subject Count Validation")
            students(studentCount).subMathExt1U = True
            chkSubjMathsExt1U.Checked = vbFalse
            Exit Sub
        End If

        If students(studentCount).subMathExt1U = True Then
            students(studentCount).subMathExt1U = False
        Else
            students(studentCount).subMathExt1U = True
        End If
        calcUnitTotal()
        chkSubjMathsExt1U.Focus()

    End Sub

    Private Sub chkSubjEng2U_CheckedChanged(sender As Object, e As EventArgs) Handles chkSubjEng2U.CheckedChanged

        If chkSubjEng2U.Checked Then
            unitCount = unitCount + txtUnitEng.Text
            subjectCount = subjectCount + 1

        Else
            unitCount = unitCount - txtUnitEng.Text
            subjectCount = subjectCount - 1

        End If

        If subjectCount = 4 Then
            MsgBox("select 1 to 3 subjects only", MsgBoxStyle.Critical, "Subject Count Validation")
            students(studentCount).subEng = True
            chkSubjEng2U.Checked = vbFalse
            Exit Sub
        End If

        If students(studentCount).subEng = True Then
            students(studentCount).subEng = False
        Else
            students(studentCount).subEng = True
        End If
        calcUnitTotal()
        chkSubjEng2U.Focus()

    End Sub

    Private Sub chkSubjSci2U_CheckedChanged(sender As Object, e As EventArgs) Handles chkSubjSci2U.CheckedChanged

        If chkSubjSci2U.Checked Then
            unitCount = unitCount + txtUnitSci.Text
            subjectCount = subjectCount + 1


        Else
            unitCount = unitCount - txtUnitSci.Text
            subjectCount = subjectCount - 1
        End If

        If subjectCount = 4 Then
            MsgBox("select 1 to 3 subjects only", MsgBoxStyle.Critical, "Subject Count Validation")
            students(studentCount).subSci = True
            chkSubjSci2U.Checked = vbFalse
            Exit Sub
        End If


        If students(studentCount).subSci = True Then
            students(studentCount).subSci = False
        Else
            students(studentCount).subSci = True
        End If
        calcUnitTotal()
        chkSubjSci2U.Focus()

    End Sub

    Private Sub chkSubjPho1U_CheckedChanged(sender As Object, e As EventArgs) Handles chkSubjPho1U.CheckedChanged

        If chkSubjPho1U.Checked Then
            unitCount = unitCount + txtUnitPho.Text
            subjectCount = subjectCount + 1
        Else
            unitCount = unitCount - txtUnitPho.Text
            subjectCount = subjectCount - 1
        End If

        If subjectCount = 4 Then
            MsgBox("select 1 to 3 subjects only", MsgBoxStyle.Critical, "Subject Count Validation")
            students(studentCount).subPho = True
            chkSubjPho1U.Checked = vbFalse
            Exit Sub
        End If

        If students(studentCount).subPho = True Then
            students(studentCount).subPho = False
        Else
            students(studentCount).subPho = True
        End If
        calcUnitTotal()
        chkSubjPho1U.Focus()

    End Sub

    Private Sub radYr10_CheckedChanged(sender As Object, e As EventArgs) Handles radYr10.CheckedChanged
        If radYr10.Checked Then
            students(studentCount).stYear = 10
        End If
    End Sub

    Private Sub radYr11_CheckedChanged(sender As Object, e As EventArgs) Handles radYr11.CheckedChanged
        If radYr11.Checked Then
            students(studentCount).stYear = 11
        End If
    End Sub

    Private Sub radYr12_CheckedChanged(sender As Object, e As EventArgs) Handles radYr12.CheckedChanged
        If radYr12.Checked Then
            students(studentCount).stYear = 12
        End If
    End Sub

    Private Sub btnFindStudent_Click(sender As Object, e As EventArgs) Handles btnFindStudent.Click
        Dim foundName = False
        Dim searchCount As Integer = 0

        'MsgBox("Test upper function " & UCase(txtLastName.Text))

        While searchCount < studentCount And foundName = False
            If UCase(students(searchCount).lastname) = UCase(txtFind.Text) Then
                foundName = True
                If foundName Then
                    lstStud.Items.Add("Your student is " & students(searchCount).firstname & " - " & students(searchCount).lastname & " - " & students(searchCount).dateGrad & " - " & students(searchCount).gender & " - " & students(searchCount).avMk & ".")
                Else
                    lstStud.Items.Add("This student cannot be found! ")
                End If
            End If
            searchCount = searchCount + 1
        End While

    End Sub

    Private Sub txtFeeTotalPaid_TextChanged(sender As Object, e As EventArgs) Handles txtFeeTotalPaid.Leave
        validateFeePaid()
    End Sub

    Private Sub txtFeeTotalCalc_TextChanged(sender As Object, e As EventArgs) Handles txtFeeTotalCalc.TextChanged

    End Sub

    Private Sub chkPaid_CheckedChanged(sender As Object, e As EventArgs) Handles chkPaid.CheckedChanged
        If students(studentCount).feePaid = True Then
            students(studentCount).feePaid = False
        Else
            students(studentCount).feePaid = True
        End If
    End Sub
End Class
