//
//  CRCustomError.h
//  CrittercismExampleApp
//
//  Created by David Shirley 2 on 3/14/15.
//  Copyright (c) 2015 Crittercism, inc. All rights reserved.
//
//  This class allows building a custom stack trace to send to Crittercism
//  as a crash or a handled exception.

#import <Foundation/Foundation.h>

typedef NS_ENUM(NSUInteger, CRCustomStackFrame) {
    crFunctionA,
    crFunctionB,
    crFunctionC,
    crFunctionD
};

@interface CRCustomError : NSObject
- (void)addFrame:(CRCustomStackFrame)frame;
- (NSUInteger)numberOfFrames;
- (NSString *)frameAtIndex:(NSUInteger)index;
- (void)clear;
- (void)crash;
- (void)raiseException;
@end
