//
//  NSURLSessionDataTaskWithHandler.m
//  CrittercismExampleApp
//
//  Created by David Shirley 2 on 1/10/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import "CRNSURLSessionDataTaskWithHandler.h"

@implementation CRNSURLSessionDataTaskWithHandler

- (void)performRequest:(NSURLRequest *)request onQueue:(NSOperationQueue *)queue
{
    NSURLSessionConfiguration *config =[NSURLSessionConfiguration defaultSessionConfiguration];

    NSURLSession *session = [NSURLSession sessionWithConfiguration:config
                                                          delegate:nil
                                                     delegateQueue:queue];

    [[session dataTaskWithRequest:request completionHandler:^(NSData *data,
                                                              NSURLResponse *response,
                                                              NSError *error)
    {
        [self.delegate requestFinishedWithResponse:response andError:error];
    }] resume];
}

@end
