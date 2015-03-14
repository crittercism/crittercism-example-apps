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

#define kCrashSection 0
#define kExceptionSection 1
#define kCustomStackSection 2

@interface CRErrorViewController ()
@property (nonatomic, strong) CRCustomError *customError;
@property (nonatomic, strong) NSArray *sectionTitles;
@property (nonatomic, retain) NSString *traceCrash;
@property (nonatomic, assign) BOOL recursingToDeath;
@end

@implementation CRErrorViewController

- (void)viewDidLoad
{
    [super viewDidLoad];
    _customError = [[CRCustomError alloc] init];

    _sectionTitles = @[ @"Force Crash:",
                        @"Handle Exception:",
                        @"Custom Stack Trace:"
                       ];

    self.recursingToDeath = NO;
    [self.tView registerNib:[UINib nibWithNibName:@"ThreeButtonTableViewCell" bundle:nil] forCellReuseIdentifier:@"ThreeButtonTableViewCell"];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

#pragma mark - Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    return _sectionTitles.count;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    if(section == kCrashSection) {
        return 3;
    } else if(section == kExceptionSection) {
        return 2;
    } else if(section == kCustomStackSection) {
        return [_customError numberOfFrames] + 2;
    }

    assert(NO);
}


- (UITableViewCell *)tableView:(UITableView *)tableView
         cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    if(indexPath.section == kCrashSection) {
        UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:@"SimpleCell" forIndexPath:indexPath];
        cell.selectionStyle = UITableViewCellSelectionStyleBlue;
        cell.textLabel.textAlignment = NSTextAlignmentLeft;
        cell.textLabel.textColor = [UIColor blueColor];
        cell.backgroundColor = [UIColor whiteColor];

        if(indexPath.row == 0) {
            cell.textLabel.text = @"Uncaught Exception";
        } else if(indexPath.row == 1) {
            cell.textLabel.text = @"Segfault";
        } else if(indexPath.row == 2) {
            cell.textLabel.text = @"Stack Overflow";
            if(self.recursingToDeath)
                cell.backgroundColor = [UIColor lightGrayColor];

        } else {
            assert(NO);
        }

        return cell;
    } else if(indexPath.section == kExceptionSection) {
        UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:@"SimpleCell" forIndexPath:indexPath];
        cell.selectionStyle = UITableViewCellSelectionStyleBlue;

        cell.textLabel.textAlignment = NSTextAlignmentLeft;
        cell.textLabel.textColor = [UIColor blueColor];

        if(indexPath.row == 0) {
            cell.textLabel.text = @"Index Out Of Bounds";
        } else if(indexPath.row == 1) {
            cell.textLabel.text = @"Log NSError";
        } else {
            assert(NO);
        }

        return cell;
    } else if(indexPath.section == kCustomStackSection) {
        if(indexPath.row == [_customError numberOfFrames] + 1) {

            ThreeButtonTableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:@"ThreeButtonTableViewCell" forIndexPath:indexPath];
            cell.selectionStyle = UITableViewCellSelectionStyleNone;
            [cell.aButton setTitle:@"CLEAR" forState:UIControlStateNormal];
            [cell.aButton addTarget:_customError
                             action:@selector(clear)
                   forControlEvents:UIControlEventTouchUpInside];

            [cell.bButton setTitle:@"EXCEPTION" forState:UIControlStateNormal];
            [cell.bButton addTarget:_customError
                             action:@selector(raiseException)
                   forControlEvents:UIControlEventTouchUpInside];

            [cell.cButton setTitle:@"CRASH" forState:UIControlStateNormal];
            [cell.cButton addTarget:_customError
                             action:@selector(crash)
                   forControlEvents:UIControlEventTouchUpInside];

            return cell;
        } else {
            UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:@"SimpleCell" forIndexPath:indexPath];
            cell.textLabel.textAlignment = NSTextAlignmentLeft;
            cell.selectionStyle = UITableViewCellSelectionStyleBlue;

            if (indexPath.row == [_customError numberOfFrames]) {
                cell.textLabel.textColor = [UIColor grayColor];

                if([_customError numberOfFrames] == 0) {
                    cell.textLabel.text = @"Add Function..";
                } else {
                    cell.textLabel.text = @"Add Another Function..";
                }
            } else {
                cell.textLabel.text = [_customError frameAtIndex:indexPath.row];
                cell.textLabel.textColor = [UIColor blackColor];
            }

            return cell;
        }
    }

    assert(NO);
}

- (void)didHitButton:(UIButton *)sender {
    sender.selected = YES;
    [self performCommand:sender.titleLabel.text];
    [self performSelector:@selector(unselectButton:) withObject:sender afterDelay:0.3];
}

- (void)unselectButton:(UIButton *)button {
    button.selected = NO;
}

- (void)performCommand:(NSString *)command {
    [[GlobalLog sharedLog] logActionString:[NSString stringWithFormat:@"[Error]: %@", command]];

    if([command hasPrefix:@"Add"]) {
        NSArray *colors = [NSArray arrayWithObjects:@"Function A", @"Function B", @"Function C", @"Function D", nil];

        [ActionSheetStringPicker showPickerWithTitle:@"Pick a function"
                                                rows:colors
                                    initialSelection:0
                                           doneBlock:^(ActionSheetStringPicker *picker, NSInteger selectedIndex, id selectedValue) {
                                               [_customError addFrame:selectedIndex];
                                               [self.tView reloadData];
                                           }
                                         cancelBlock:^(ActionSheetStringPicker *picker) {
                                         }
                                              origin:self.view];
    } else if([command isEqualToString:@"Uncaught Exception"]) {
        NSLog(@"Raising custom uncaught exception");
        [NSException raise:@"Raised Exception" format:@"This is a forced uncaught exception"];
    } else if([command isEqualToString:@"Segfault"]) {
        NSLog(@"Calling kill with SIGSEGV");
        kill(getpid(), SIGSEGV);
    } else if([command isEqualToString:@"Stack Overflow"]) {
        self.recursingToDeath = YES;
        [self.tView reloadData];
        [self performSelector:@selector(recurse) withObject:nil afterDelay:1];

    } else if([command isEqualToString:@"Index Out Of Bounds"]) {
        @try {
            NSString *huh = @[][1];
            NSLog(@"be quiet warnings: %@", huh);
        } @catch (NSException *exception) {
            NSLog(@"Logging exception: %@", [exception description]);
            [Crittercism logHandledException:exception];
        }
    } else if([command isEqualToString:@"Log NSError"]) {
        NSError *error = nil;
        [[NSFileManager defaultManager] removeItemAtPath:@"ThisFileDoesntExist" error:&error];
        if (error) {
            NSLog(@"Logging error: %@", [error localizedDescription]);
            [Crittercism logError:error];
        }
    } else {
        [[[UIAlertView alloc] initWithTitle:command message:@"" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil] show];
    }
}

- (void)recurse {
    NSLog(@"Recursing infintely.. ");
    [self recurse];
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath
{
    if(indexPath.section == kCustomStackSection && indexPath.row == [_customError numberOfFrames] + 1)
    {
        return 83;
    }
    return 44;
}

- (void) tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{

    if(indexPath.section == kCrashSection || indexPath.section == kExceptionSection || (indexPath.section == 2 && indexPath.row == [_customError numberOfFrames]))
    {
        [self performCommand:[self.tView cellForRowAtIndexPath:indexPath].textLabel.text];
    }

    [self performSelector:@selector(fadeSelection:) withObject:[NSNumber numberWithBool:YES] afterDelay:0.3];
}

- (void)fadeSelection:(BOOL)animated {
    NSIndexPath*    selection = [self.tView indexPathForSelectedRow];
    if (selection) {
        [self.tView deselectRowAtIndexPath:selection animated:animated];
    }
}

- (NSString *)tableView:(UITableView *)tableView titleForHeaderInSection:(NSInteger)section {
    return _sectionTitles[section];
}

- (NSString *)tableView:(UITableView *)tableView titleForFooterInSection:(NSInteger)section
{
    if(section == kCrashSection && self.recursingToDeath) {
        return @"      ...app doomed... patience grasshopper...  ";
    }

    return nil;
}

@end
