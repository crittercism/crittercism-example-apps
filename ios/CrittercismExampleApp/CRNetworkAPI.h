//
//  NetworkAPI.h
//  CrittercismExampleApp
//
//  Created by David Shirley 2 on 1/10/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import <Foundation/Foundation.h>

@protocol NetworkAPIDelegate
- (void)requestFinishedWithResponse:(NSURLResponse *)response
                           andError:(NSError *)error;
@end

@interface CRNetworkAPI : NSObject
@property (nonatomic, strong) id<NetworkAPIDelegate> delegate;

- (id)initWithDelegate:(id<NetworkAPIDelegate>)delegate;
- (void)performRequest:(NSURLRequest *)request onQueue:(NSOperationQueue *)queue;
@end

