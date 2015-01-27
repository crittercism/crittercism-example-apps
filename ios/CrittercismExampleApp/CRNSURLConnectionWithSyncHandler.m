//
//  NSURLConnectionWithSyncHandler.m
//  CrittercismExampleApp
//
//  Created by David Shirley 2 on 1/10/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import "CRNSURLConnectionWithSyncHandler.h"

@implementation CRNSURLConnectionWithSyncHandler

- (void)performRequest:(NSURLRequest *)request onQueue:(NSOperationQueue *)queue
{
    NSBlockOperation *op = [NSBlockOperation blockOperationWithBlock:^(void) {
        NSURLResponse *response = nil;
        NSError *error = nil;

        [NSURLConnection sendSynchronousRequest:request
                              returningResponse:&response
                                          error:&error];

        [self.delegate requestFinishedWithResponse:response andError:error];
    }];

    [queue addOperation:op];
}

@end
