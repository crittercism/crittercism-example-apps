//
//  NetworkAPI.m
//  CrittercismExampleApp
//
//  Created by David Shirley 2 on 1/10/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import "CRNetworkAPI.h"

@implementation CRNetworkAPI

- (id)initWithDelegate:(id<NetworkAPIDelegate>)delegate
{
    self = [super init];

    if (self) {
        _delegate = delegate;
    }

    return self;
}

- (void)performRequest:(NSURLRequest *)request onQueue:(NSOperationQueue *)queue
{
    [NSException raise:@"not implemented" format:nil];
}

@end
