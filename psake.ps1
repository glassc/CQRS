# Helper script for those who want to run
# psake without importing the module.
import-module .\psake.psm1
invoke-psake @args "4.0"
remove-module psake