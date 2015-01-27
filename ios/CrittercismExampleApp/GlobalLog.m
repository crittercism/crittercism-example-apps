//
//  GlobalLog.m
//  CrittercismExampleApp
//
//  Created by Einar Vollset on 1/16/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//

#import "GlobalLog.h"


@interface GlobalLog ()
@property (nonatomic, retain) NSMutableArray *log;
@end

@implementation GlobalLog


+ (id)sharedLog {
    static GlobalLog *sharedLog = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        sharedLog = [[self alloc] init];
        NSArray *maybe = [[NSUserDefaults standardUserDefaults] arrayForKey:@"log"];
        if(maybe)
            sharedLog.log = [NSMutableArray arrayWithArray:maybe];
        else
            sharedLog.log = [NSMutableArray array];
    });
    return sharedLog;
}

- (id)init {
    if (self = [super init]) {
    }
    return self;
}

- (void)dealloc {
}


- (void) logActionString:(NSString *)action
{
    [self.log addObject:action];
    [[NSUserDefaults standardUserDefaults] setObject:self.log forKey:@"log"];
    [[NSUserDefaults standardUserDefaults] synchronize];
}

- (int) logCount
{
    
    return (int)[self.log count];
}
- (NSString *) logItemAtIndex:(int) index
{
    return [self.log objectAtIndex:index];
}
- (void) clearLog
{
    [[NSUserDefaults standardUserDefaults] removeObjectForKey:@"log"];
    [[NSUserDefaults standardUserDefaults] synchronize];
    self.log = [NSMutableArray array];
}
@end
