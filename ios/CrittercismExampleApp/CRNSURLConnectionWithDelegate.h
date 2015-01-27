//
//  NSURLConnectionWithDelegate.h
//  CrittercismExampleApp
//
//  Created by David Shirley 2 on 1/10/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import "CRNetworkAPI.h"

@interface CRNSURLConnectionWithDelegate : CRNetworkAPI
- (void)performRequest:(NSURLRequest *)request onQueue:(NSOperationQueue *)queue;
@end
