package com.crittercism.network.apis;

/**
 * Created by dshirley on 3/30/15.
 */
public class GenericResponse {

    private Exception error;
    private int status;
    private String body;

    public GenericResponse(int status, String body) {
        this.status = status;
        this.body = body;
        this.error = null;
    }

    public GenericResponse(Exception error) {
        this.error = error;
        this.status = -1;
        this.body = null;
    }

    public int getStatus() {
        return status;
    }

    public void setStatus(int status) {
        this.status = status;
    }

    public String getBody() {
        return body;
    }

    public void setBody(String body) {
        this.body = body;
    }
}
