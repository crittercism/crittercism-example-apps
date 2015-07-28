package com.crittercism.errors;

public class NativeCustomError extends CustomError {

    protected native boolean crash(String crashType);

    static {
        System.loadLibrary("crash");
    }

}
