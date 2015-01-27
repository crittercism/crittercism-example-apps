//
//  CRNSURLSessionDataTaskWithDelegate.m
//  CrittercismExampleApp
//
//  Created by David Shirley 2 on 1/12/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import "CRNSURLSessionDataTaskWithDelegate.h"
#import "CRNSURLSessionDelegate.h"

@implementation CRNSURLSessionDataTaskWithDelegate

- (void)performRequest:(NSURLRequest *)request onQueue:(NSOperationQueue *)queue
{
    NSURLSessionConfiguration *config =[NSURLSessionConfiguration defaultSessionConfiguration];
    CRNSURLSessionDelegate *delegate = [[CRNSURLSessionDelegate alloc] initWithDelegate:self.delegate];

    NSURLSession *session = [NSURLSession sessionWithConfiguration:config
                                                          delegate:delegate
                                                     delegateQueue:queue];

    [[session dataTaskWithRequest:request] resume];
}

@end
