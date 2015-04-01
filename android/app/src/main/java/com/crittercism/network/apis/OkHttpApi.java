package com.crittercism.network.apis;

import com.squareup.okhttp.MediaType;
import com.squareup.okhttp.OkHttpClient;
import com.squareup.okhttp.RequestBody;
import com.squareup.okhttp.Response;
import com.squareup.okhttp.Request;

import org.apache.http.HttpStatus;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

/**
 * Created by dshirley on 3/30/15.
 */
public class OkHttpApi implements NetworkApi {
    public static final MediaType PLAIN_TEXT = MediaType.parse("text/plain; charset=utf-8");

    @Override
    public GenericResponse execute(GenericRequest request) {
        try {
            return doExecute(request);
        } catch (IOException e) {
            return new GenericResponse(e);
        }
    }

    public GenericResponse doExecute(GenericRequest request) throws IOException {
        OkHttpClient client = new OkHttpClient();
        Response okResponse;
        Request okRequest;
        int status = -1;

        Request.Builder builder = new Request.Builder();
        builder.url(request.getUrl());

        if (request.getMethod().toUpperCase().equals("POST")) {
            RequestBody body = RequestBody.create(PLAIN_TEXT, request.getPostData());
            builder.post(body);
        }

        okResponse = client.newCall(builder.build()).execute();

        return new GenericResponse(okResponse.code(), okResponse.body().string());
    }

}
