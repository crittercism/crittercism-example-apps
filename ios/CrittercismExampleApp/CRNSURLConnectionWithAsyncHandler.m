//
//  NSURLConnectionWithAsyncHandler.m
//  CrittercismExampleApp
//
//  Created by David Shirley 2 on 1/10/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import "CRNSURLConnectionWithAsyncHandler.h"

@implementation CRNSURLConnectionWithAsyncHandler

- (void)performRequest:(NSURLRequest *)request onQueue:(NSOperationQueue *)queue
{
    [NSURLConnection sendAsynchronousRequest:request
                                       queue:queue
                           completionHandler:^(NSURLResponse *response,
                                               NSData *data,
                                               NSError *error)
    {
        [self.delegate requestFinishedWithResponse:response andError:error];
    }];
}

@end
