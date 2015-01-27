//
//  CRNSURLSessionDataTaskWithDelegate.h
//  CrittercismExampleApp
//
//  Created by David Shirley 2 on 1/12/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import "CRNetworkAPI.h"

@interface CRNSURLSessionDataTaskWithDelegate : CRNetworkAPI
- (void)performRequest:(NSURLRequest *)request onQueue:(NSOperationQueue *)queue;
@end
