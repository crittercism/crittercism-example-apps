package com.crittercism.network.apis;

import java.net.URL;

/**
 * Created by dshirley on 3/30/15.
 */
public class GenericRequest {

    private String method = "GET";
    private URL url = null;
    private String postData = null;

    public GenericRequest(URL url) {
        this("GET", url, null);
    }

    public GenericRequest(String method, URL url, String postData) {
        this.method = method;
        this.url = url;
        this.postData = postData;
    }

    public String getMethod() {
        return method;
    }

    public URL getUrl() {
        return url;
    }

    public String getPostData() {
        return postData;
    }

    public void setMethod(String method) {
        this.method = method;
    }

    public void setUrl(URL url) {
        this.url = url;
    }

    public void setPostData(String postData) {
        this.postData = postData;
    }
}
