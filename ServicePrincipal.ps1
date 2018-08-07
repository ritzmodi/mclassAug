
$pass = ConvertTo-SecureString -String "password" -AsPlainText -Force

New-AzureRmADApplication -DisplayName "mclassAug18" -IdentifierUris "http://armtemplate.com" -HomePage "http://armtemplate.com" -Password $pass -Verbose

New-AzureRmADServicePrincipal -ApplicationId 44222288-609d-4742-acf7-5d5274afa701 -Password $pass

New-AzureRmRoleAssignment -ApplicationId 44222288-609d-4742-acf7-5d5274afa701 -RoleDefinitionName owner

Login-AzureRmAccount -Credential $(Get-Credential) -TenantId 771f1cf4-b1ac-4f2e-ad21-de39ea201e7e -ServicePrincipal
