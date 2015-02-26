//
//  OtherViewController.m
//  CrittercismExampleApp
//
//  Created by Einar Vollset on 11/13/14.
//  Copyright (c) 2014 Crittercism. All rights reserved.
//

#import "CROtherViewController.h"
#import "Crittercism.h"
#import "GlobalLog.h"

#define kUsernameSection 0
#define kMetaDataSection 1
#define kBreadcrumbsSection 2
#define kOutOutStatus 3

@interface CROtherViewController ()
@property (nonatomic, strong) NSArray *usernames;
@property (nonatomic, strong) NSArray *metadata;
@end

@implementation CROtherViewController

- (void)viewDidLoad {
    _usernames = @[ @"Bob", @"Jim", @"Sue" ];
    _metadata = @[ @"5", @"30", @"50" ];
    [super viewDidLoad];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
}


#pragma mark - Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    return 4;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    if (section == kUsernameSection) {
        return _usernames.count;
    } else if (section == kMetaDataSection) {
        return _metadata.count;
    } else if(section == kBreadcrumbsSection || section == kOutOutStatus) {
        return 3;
    }
    
    assert(NO);
}


- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:@"SimpleCell" forIndexPath:indexPath];
    cell.textLabel.textAlignment = NSTextAlignmentLeft;
    cell.textLabel.textColor = [UIColor blackColor];
    
    if(indexPath.section == kUsernameSection)
    {
        cell.textLabel.text = _usernames[indexPath.row];
        return cell;
    }
    else if(indexPath.section == kMetaDataSection)
    {
        cell.textLabel.text = _metadata[indexPath.row];
        return cell;
    }
    else if(indexPath.section == kBreadcrumbsSection)
    {
        
        if(indexPath.row == 0)
        {
            cell.textLabel.text = [NSString stringWithFormat:@"Leave: 'hello world'"];
        }
        else if(indexPath.row == 1)
        {
            cell.textLabel.text = [NSString stringWithFormat:@"Leave: 'abc'"];
        }
        else if(indexPath.row == 2)
        {
            cell.textLabel.text = [NSString stringWithFormat:@"Leave: '123'"];
        }
        else
        {
            assert(NO);
        }
        
        return cell;
    }
    else if(indexPath.section == kOutOutStatus)
    {
                
        if(indexPath.row == 0)
        {
            cell.textLabel.text = [NSString stringWithFormat:@"Opt Out"];
        }
        else if(indexPath.row == 1)
        {
            cell.textLabel.text = [NSString stringWithFormat:@"Opt In"];
        }
        else if(indexPath.row == 2)
        {
            cell.textLabel.text = [NSString stringWithFormat:@"Check Opt-Out Status"];
            cell.textLabel.textAlignment = NSTextAlignmentCenter;
            cell.textLabel.textColor = [UIColor blueColor];
        }
        else
        {
            assert(NO);
        }
        
        return cell;
    }


    
    assert(NO);
}

- (void) executeCommand:(UIButton *)sender
{
    NSLog(@"%@", sender.titleLabel.text);
}


- (CGFloat) tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath
{
    return 44;
}


- (NSString *)tableView:(UITableView *)tableView titleForHeaderInSection:(NSInteger)section
{
    if(section == kUsernameSection)
    {
        return @"Set Username:";
    }
    else if(section == kMetaDataSection)
    {
        return @"Set Metadata:";
    }
    else if(section == kBreadcrumbsSection)
    {
        return @"BreadCrumbs:";
    }
    else if(section == kOutOutStatus)
    {
        return @"Opt-out Status:";
    }
    
    assert(NO);
}

- (void) performCommand:(NSString *)command
{
    [[GlobalLog sharedLog] logActionString:[NSString stringWithFormat:@"[Other]: %@", command]];

    
    NSArray *components = [command componentsSeparatedByString:@" "];
    
    NSString *uniqueThing = [components lastObject];

    if([uniqueThing hasSuffix:@"'"])
    {
        NSArray *components = [command componentsSeparatedByString:@"'"];
        NSString *breadCrumb = [components objectAtIndex:1];
        NSLog(@"Leaving breadcrumb %@", breadCrumb);
        [Crittercism leaveBreadcrumb:breadCrumb];
    }
    else if([uniqueThing isEqualToString:@"Out"])
    {
        [Crittercism setOptOutStatus:YES];
    }
    else if([uniqueThing isEqualToString:@"In"])
    {
        [Crittercism setOptOutStatus:NO];
    }
    else if([uniqueThing isEqualToString:@"Status"])
    {
        if([Crittercism getOptOutStatus])
        {
            [[[UIAlertView alloc] initWithTitle:@"OptOutStatus" message:@"is YES" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil] show];
        }
        else
        {
            
            [[[UIAlertView alloc] initWithTitle:@"OptOutStatus" message:@"is NO" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil] show];
        }
        
    }
    else
    {
        [[[UIAlertView alloc] initWithTitle:command message:@"" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil] show];
    }
}


- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    if (indexPath.section == kUsernameSection) {
        [Crittercism setUsername:_usernames[indexPath.row]];
        return;
    } else if (indexPath.section == kMetaDataSection) {
        [Crittercism setValue:_metadata[indexPath.row] forKey:@"Game Level"];
        return;
    }
    
    [self performCommand:[self.tView cellForRowAtIndexPath:indexPath].textLabel.text];
    [self performSelector:@selector(fadeSelection:) withObject:[NSNumber numberWithBool:YES] afterDelay:0.3];
}

- (void)fadeSelection:(BOOL)animated
{
    NSIndexPath*    selection = [self.tView indexPathForSelectedRow];
    if (selection) {
        [self.tView deselectRowAtIndexPath:selection animated:animated];
    }
}

@end
