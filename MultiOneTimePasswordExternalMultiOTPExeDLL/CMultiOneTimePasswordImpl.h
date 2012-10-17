/* * * * * * * * * * * * * * * * * * * * *
**
** Copyright 2012 Dominik Pretzsch
** 
**    Licensed under the Apache License, Version 2.0 (the "License");
**    you may not use this file except in compliance with the License.
**    You may obtain a copy of the License at
** 
**        http://www.apache.org/licenses/LICENSE-2.0
** 
**    Unless required by applicable law or agreed to in writing, software
**    distributed under the License is distributed on an "AS IS" BASIS,
**    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
**    See the License for the specific language governing permissions and
**    limitations under the License.
**
** * * * * * * * * * * * * * * * * * * */

#pragma once

#define EXPORTING
#include "CMultiOneTimePassword.h"
#include "CallExternalMultiOTPExe.h"

class /*DllExport*/ CMultiOneTimePassword : public IMultiOneTimePassword
{
	public:
		CMultiOneTimePassword(void);
		~CMultiOneTimePassword(void);
		HRESULT OTPCheckPassword(PWSTR username, PWSTR otp);
		HRESULT OTPResync(PWSTR username, PWSTR otp1, PWSTR otp2);
	private:
		HRESULT _MultiOTPExitCodeToHRESULT(DWORD exitCode);
	protected:
		const int i; // dummy
};


