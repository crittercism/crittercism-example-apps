//
//  CRCrashOnNextAppLoad.h
//  Crittercism-iOS
//
//  Created by Vera Lukman on 1/26/16.
//  Copyright © 2016 Crittercism. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface CRCrashOnNextAppLoad : NSObject

- (BOOL)shouldCrashOnNextAppLoad;
- (void)setCrashOnNextAppLoad;
- (void)setNormalStartOnNextAppLoad;

@end
