package com.crittercism.errors;

import com.crittercism.app.Crittercism;

import java.io.File;

public class IllegalArgumentCustomError extends CustomError {
    @Override
    protected void performError() throws Throwable {
        super.performError();                try {
            new File("abcd").setLastModified(-50);
        } catch (Exception e) {
            Crittercism.logHandledException(e);
        }
    }
}
