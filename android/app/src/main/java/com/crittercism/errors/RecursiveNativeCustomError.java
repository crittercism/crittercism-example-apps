package com.crittercism.errors;

public class RecursiveNativeCustomError extends NativeCustomError {

    @Override
    protected void performError() throws Throwable {
        crash("do_recursive_crash");
    }
}
