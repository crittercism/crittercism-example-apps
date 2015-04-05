package com.crittercism.network.apis;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.util.Locale;

/**
 * Created by dshirley on 3/30/15.
 */
public class HttpURLConnectionApi implements NetworkApi {

    @Override
    public GenericResponse execute(GenericRequest request) {
        try {
            return doExecute(request);
        } catch (IOException e) {
            return new GenericResponse(e);
        }
    }

    public GenericResponse doExecute(GenericRequest request) throws IOException {
        HttpURLConnection conn = (HttpURLConnection) request.getUrl().openConnection();
        conn.setRequestMethod(request.getMethod());

        if (conn.getRequestMethod().toUpperCase(Locale.getDefault()).equals("POST")) {
            conn.getOutputStream().write(request.getPostData().getBytes());
        }


        BufferedReader in = new BufferedReader(new InputStreamReader(conn.getInputStream()));
        StringBuilder sb = new StringBuilder();
        int c = -1;

        while ((c = in.read()) != -1) {
            sb.append((char) c);
        }

        in.close();
        conn.disconnect();

        return new GenericResponse(conn.getResponseCode(), sb.toString());
    }

}
