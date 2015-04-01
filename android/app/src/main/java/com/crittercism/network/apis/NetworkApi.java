package com.crittercism.network.apis;

/**
 * Created by dshirley on 3/30/15.
 */
public interface NetworkApi {

    /**
     * Executes the given network request using a specific network API.
     * @param request A description of a network request
     * @return The response from the server
     */
    public GenericResponse execute(GenericRequest request);
}
