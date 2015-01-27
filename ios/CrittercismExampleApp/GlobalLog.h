//
//  GlobalLog.h
//  CrittercismExampleApp
//
//  Created by Einar Vollset on 1/16/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface GlobalLog : NSObject

+ (GlobalLog *) sharedLog;

- (void) logActionString:(NSString *)action;

- (int) logCount;
- (NSString *) logItemAtIndex:(int) index;
- (void) clearLog;

@end
