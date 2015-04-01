package com.crittercism.errors;

/**
 * Created by dshirley on 3/31/15.
 */
public class NullPointerCustomError extends CustomError {

    @Override
    protected void performError() throws Throwable {
        ((String) null).length();
    }
}
