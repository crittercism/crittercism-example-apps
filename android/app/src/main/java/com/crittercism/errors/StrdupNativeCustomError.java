package com.crittercism.errors;

public class StrdupNativeCustomError extends NativeCustomError {

    @Override
    protected void performError() throws Throwable {
        crash("do_strdup_crash");
    }
}
