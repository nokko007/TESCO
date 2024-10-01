
Public Class CustomRadioButton
    Inherits RadioButton

    Protected Overrides Function IsInputKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
        If keyData = Keys.Tab Then
            Return True
        End If

        Return MyBase.IsInputKey(keyData)
    End Function

End Class

