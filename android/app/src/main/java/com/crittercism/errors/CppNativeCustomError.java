package com.crittercism.errors;

public class CppNativeCustomError extends NativeCustomError {

    @Override
    protected void performError() throws Throwable {
        crash("do_cpp_crash");
    }
}
