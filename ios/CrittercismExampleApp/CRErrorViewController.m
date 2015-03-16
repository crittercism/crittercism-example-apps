//
//  ErrorViewController.m
//  CrittercismExampleApp
//
//  Created by Einar Vollset on 11/13/14.
//  Copyright (c) 2014 Crittercism. All rights reserved.
//

#import "CRErrorViewController.h"
#import "ThreeButtonTableViewCell.h"
#import "ActionSheetStringPicker.h"
#import "Crittercism.h"
#import "GlobalLog.h"
#import "CRCustomError.h"
#import "CRSingleButtonTableViewCell.h"
#import "CRFourButtonTableViewCell.h"

#define kCrashSection 0
#define kExceptionSection 1
#define kCustomStackSection 2

@interface CRErrorViewController ()
@property (nonatomic, strong) CRCustomError *customError;
@property (nonatomic, strong) NSArray *sectionTitles;
@property (nonatomic, strong) NSArray *crashSection;
@property (nonatomic, strong) NSArray *exceptionSection;
@property (nonatomic, retain) NSString *traceCrash;
@end

@implementation CRErrorViewController

#define SEL2STR(sel) (NSStringFromSelector(@selector(sel)))

- (void)viewDidLoad
{
    [super viewDidLoad];
    _customError = [[CRCustomError alloc] init];

    _sectionTitles = @[ @"Force Crash:",
                        @"Handle Exception:",
                        @"Custom Stack Trace:"
                       ];

    _crashSection = @[ @[ @"Uncaught Exception", SEL2STR(crashUncaughtException) ],
                       @[ @"Segfault", SEL2STR(crashSegfault) ],
                       @[ @"Stack Overflow", SEL2STR(crashStackOverflow) ]];

    _exceptionSection = @[ @[ @"Index Out Of Bounds", SEL2STR(raiseExceptionIndexOutOfBounds) ],
                           @[ @"Log NSError", SEL2STR(logNSError) ]];
}

#pragma mark - UITableViewDataSource Methods

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    return _sectionTitles.count;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    if(section == kCrashSection) {
        return _crashSection.count;
    } else if(section == kExceptionSection) {
        return _exceptionSection.count;
    } else if(section == kCustomStackSection) {
        return [_customError numberOfFrames] + 1;
    }

    assert(NO);
}

- (NSString *)tableView:(UITableView *)tableView titleForHeaderInSection:(NSInteger)section {
    return _sectionTitles[section];
}

- (UITableViewCell *)tableView:(UITableView *)tableView
         simpleCellForRowAtIndexPath:(NSIndexPath *)indexPath
         andSectionDescription:(NSArray *)sectionDescription
{
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:@"SingleButtonCell"
                                                            forIndexPath:indexPath];

    UIButton *button = [(CRSingleButtonTableViewCell *)cell button];

    [button setTitle:sectionDescription[indexPath.row][0] forState:UIControlStateNormal];
    [button addTarget:self
               action:NSSelectorFromString(sectionDescription[indexPath.row][1])
     forControlEvents:UIControlEventTouchUpInside];

    return cell;
}

- (UITableViewCell *)tableView:(UITableView *)tableView
         cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    UITableViewCell *cell = nil;

    if(indexPath.section == kCrashSection) {
        return [self tableView:tableView simpleCellForRowAtIndexPath:indexPath andSectionDescription:_crashSection];
    } else if(indexPath.section == kExceptionSection) {
        return [self tableView:tableView simpleCellForRowAtIndexPath:indexPath andSectionDescription:_exceptionSection];
    } else if(indexPath.section == kCustomStackSection) {
        if(indexPath.row == [_customError numberOfFrames]) {

            CRFourButtonTableViewCell *fourButtonCell = [tableView dequeueReusableCellWithIdentifier:@"StackTraceControllsCell" forIndexPath:indexPath];

            [fourButtonCell.aButton addTarget:self
                       action:@selector(addStackFrame)
             forControlEvents:UIControlEventTouchUpInside];

            [fourButtonCell.bButton addTarget:self
                             action:@selector(clearStackTrace)
                   forControlEvents:UIControlEventTouchUpInside];

            [fourButtonCell.cButton addTarget:_customError
                             action:@selector(raiseException)
                   forControlEvents:UIControlEventTouchUpInside];

            [fourButtonCell.dButton addTarget:_customError
                             action:@selector(crash)
                   forControlEvents:UIControlEventTouchUpInside];

            cell = fourButtonCell;
        } else {
            cell = [tableView dequeueReusableCellWithIdentifier:@"StackFrameCell"
                                                   forIndexPath:indexPath];

            cell.textLabel.text = [_customError frameAtIndex:indexPath.row];
        }
    }

    NSAssert(cell, @"no cell for index path: %@", indexPath);

    return cell;
}

#pragma mark Button Actions

- (void)addStackFrame {
    NSArray *colors = @[ @"Function A",
                         @"Function B",
                         @"Function C",
                         @"Function D" ];

    [ActionSheetStringPicker showPickerWithTitle:@"Pick a function"
                                            rows:colors
                                initialSelection:0
                                       doneBlock:^(ActionSheetStringPicker *picker,
                                                   NSInteger selectedIndex,
                                                   id selectedValue)
    {
        [_customError addFrame:selectedIndex];
        [self.tView reloadData];
    } cancelBlock:^(ActionSheetStringPicker *picker) {
    } origin:self.view];
}

- (void)raiseExceptionIndexOutOfBounds {
    @try {
        (void) @[][1];
    } @catch (NSException *exception) {
        [Crittercism logHandledException:exception];
    }
}

- (void)logNSError {
    [Crittercism logError:[NSError errorWithDomain:@"CritterDomain"
                                              code:123
                                          userInfo:@{ @"key" : @"value" }]];
}

- (void)crashUncaughtException {
    [NSException raise:@"Raised Exception" format:@"This is a forced uncaught exception"];
}

- (void)crashSegfault {
    int *nullVariable = NULL;
    NSLog(@"%d", *nullVariable);
}

- (void)crashStackOverflow {
    // Allocate some memory on the stack to make the stack overflow
    // go faster
    NSInteger myIntegers[2048];

    for (int i = 0; i < 2048; i++) {
        myIntegers[i] = 0;
    }

    [self crashStackOverflow];
}

- (void)clearStackTrace {
    [_customError clear];
    [_tView reloadData];
}

@end
