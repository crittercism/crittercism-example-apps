package com.crittercism.errors;

import com.crittercism.app.Crittercism;

import org.json.JSONException;
import org.json.JSONObject;

public class JsonCustomError extends CustomError {

    @Override
    protected void performError() throws Throwable {
        super.performError();                try {
            new JSONObject("{ invalid object");
        } catch (JSONException e) {
            Crittercism.logHandledException(e);
        }
    }

}
