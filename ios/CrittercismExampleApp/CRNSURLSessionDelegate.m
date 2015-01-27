//
//  CRNSURLSessionDelegate.m
//  CrittercismExampleApp
//
//  Created by David Shirley 2 on 1/12/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import "CRNSURLSessionDelegate.h"

@interface CRNSURLSessionDelegate()
@property (nonatomic, strong) id<NetworkAPIDelegate> delegate;
@end

@implementation CRNSURLSessionDelegate

- (id)initWithDelegate:(id<NetworkAPIDelegate>)delegate
{
    self = [super init];

    if (self) {
        _delegate = delegate;
    }

    return self;
}

- (void)URLSession:(NSURLSession *)session task:(NSURLSessionTask *)task
didCompleteWithError:(NSError *)error
{
    [_delegate requestFinishedWithResponse:task.response andError:error];
}

@end
