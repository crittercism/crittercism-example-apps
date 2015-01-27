//
//  NSURLConnectionWithDelegate.m
//  CrittercismExampleApp
//
//  Created by David Shirley 2 on 1/10/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import "CRNSURLConnectionWithDelegate.h"
#import "CRNetworkAPI.h"

@interface CRNSURLConnectionDelegate : NSObject
@property (nonatomic, strong) NSURLResponse *response;
@property (nonatomic, strong) id<NetworkAPIDelegate> delegate;

- (id)initWithNetworkApiDelegate:(id<NetworkAPIDelegate>)delegate;

- (void)connection:(NSURLConnection *)connection didFailWithError:(NSError *)error;
- (void)connectionDidFinishLoading:(NSURLConnection *)connection;
- (void)connection:(NSURLConnection *)connection didReceiveResponse:(NSURLResponse *)response;
@end

@implementation CRNSURLConnectionWithDelegate

- (void)performRequest:(NSURLRequest *)request onQueue:(NSOperationQueue *)queue;
{
    CRNSURLConnectionDelegate *delegate = [[CRNSURLConnectionDelegate alloc] initWithNetworkApiDelegate:self.delegate];

    NSURLConnection *conn = [[NSURLConnection alloc] initWithRequest:request
                                                            delegate:delegate
                                                    startImmediately:NO];

    [conn setDelegateQueue:queue];
    [conn start];
}

@end

@implementation CRNSURLConnectionDelegate

- (id)initWithNetworkApiDelegate:(id<NetworkAPIDelegate>)delegate {
    self = [super init];

    if (self) {
        _delegate = delegate;
    }

    return self;
}

- (void)connection:(NSURLConnection *)connection didFailWithError:(NSError *)error {
    [_delegate requestFinishedWithResponse:_response andError:error];
}

- (void)connectionDidFinishLoading:(NSURLConnection *)connection {
    [_delegate requestFinishedWithResponse:_response andError:nil];
}

- (void)connection:(NSURLConnection *)connection didReceiveResponse:(NSURLResponse *)response {
    _response = response;
}
@end
