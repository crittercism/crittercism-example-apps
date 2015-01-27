//
//  CRNSURLSessionDownloadTaskWithHandler.m
//  CrittercismExampleApp
//
//  Created by David Shirley 2 on 1/12/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import "CRNSURLSessionDownloadTaskWithHandler.h"

@implementation CRNSURLSessionDownloadTaskWithHandler

- (void)performRequest:(NSURLRequest *)request onQueue:(NSOperationQueue *)queue
{
    NSURLSessionConfiguration *config =[NSURLSessionConfiguration defaultSessionConfiguration];

    NSURLSession *session = [NSURLSession sessionWithConfiguration:config
                                                          delegate:nil
                                                     delegateQueue:queue];

    [[session downloadTaskWithRequest:request completionHandler:^(NSURL *location,
                                                                  NSURLResponse *response,
                                                                  NSError *error)
    {
        [self.delegate requestFinishedWithResponse:response andError:error];
    }] resume];
}


@end
