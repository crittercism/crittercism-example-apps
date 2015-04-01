package com.crittercism.errors;

/**
 * Created by dshirley on 3/31/15.
 */
public class IndexOutOfBoundsCustomError extends CustomError {

    @Override
    protected void performError() throws Throwable {
        int abc[] = new int[3];
        android.util.Log.e("Crittercism", "Index out of bounds thrown here" + abc[5]);
    }

}
