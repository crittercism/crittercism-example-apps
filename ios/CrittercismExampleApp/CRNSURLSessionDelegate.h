//
//  CRNSURLSessionDelegate.h
//  CrittercismExampleApp
//
//  Created by David Shirley 2 on 1/12/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "CRNetworkAPI.h"

@interface CRNSURLSessionDelegate : NSObject <NSURLSessionTaskDelegate>

- (id)initWithDelegate:(id<NetworkAPIDelegate>)delegate;

- (void)URLSession:(NSURLSession *)session task:(NSURLSessionTask *)task
didCompleteWithError:(NSError *)error;

@end
