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

@end

@implementation CROtherViewController

- (void)viewDidLoad {
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
    
    
    if(section == kUsernameSection || section == kMetaDataSection)
    {
        return 4;
    }
    
    else if(section == kBreadcrumbsSection || section == kOutOutStatus)
    {
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
        
        if(indexPath.row == 0)
        {
            cell.textLabel.text = [NSString stringWithFormat:@"Set Username: Bob"];
        }
        else if(indexPath.row == 1)
        {
            cell.textLabel.text = [NSString stringWithFormat:@"Set Username: Jim"];
        }
        else if(indexPath.row == 2)
        {
            cell.textLabel.text = [NSString stringWithFormat:@"Set Username: Sue"];
        }
        else if(indexPath.row == 3)
        {
            cell.textLabel.text = [NSString stringWithFormat:@"Check Username"];
            cell.textLabel.textAlignment = NSTextAlignmentCenter;
            cell.textLabel.textColor = [UIColor blueColor];
        }
        else
        {
            assert(NO);
        }
        
        return cell;
    }
    else if(indexPath.section == kMetaDataSection)
    {
        
        if(indexPath.row == 0)
        {
            cell.textLabel.text = [NSString stringWithFormat:@"Set Game Level: 5"];
        }
        else if(indexPath.row == 1)
        {
            cell.textLabel.text = [NSString stringWithFormat:@"Set Game Level: 30"];
        }
        else if(indexPath.row == 2)
        {
            cell.textLabel.text = [NSString stringWithFormat:@"Set Game Level: 50"];
        }
        else if(indexPath.row == 3)
        {
            cell.textLabel.text = [NSString stringWithFormat:@"Check Game Level"];
            cell.textLabel.textAlignment = NSTextAlignmentCenter;
            cell.textLabel.textColor = [UIColor blueColor];
        }
        else
        {
            assert(NO);
        }
        
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


- (NSString *) tableView:(UITableView *)tableView titleForHeaderInSection:(NSInteger)section
{
    if(section == kUsernameSection)
    {
        return @"Username:";
    }
    else if(section == kMetaDataSection)
    {
        return @"Metadata:";
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
    
    
    
    if([uniqueThing isEqualToString:@"Bob"] || [uniqueThing isEqualToString:@"Sue"]  || [uniqueThing isEqualToString:@"Jim"]  )
    {
        [Crittercism setUsername:uniqueThing];
    }
    else if([uniqueThing isEqualToString:@"Username"])
    {
        //[[[UIAlertView alloc] initWithTitle:@"Username" message:[NSString stringWithFormat:@"Username value = %@", [Crittercism getUsername]] delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil] show];
        
        [[[UIAlertView alloc] initWithTitle:@"Missing SDK part" message:@"No getUsername: in SDK" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil] show];

    }
    else if([uniqueThing isEqualToString:@"5"] || [uniqueThing isEqualToString:@"30"]  || [uniqueThing isEqualToString:@"50"]  )
    {
        [Crittercism setValue:uniqueThing forKey:@"Game Level"];
    }
    else if([uniqueThing isEqualToString:@"Level"])
    {
     //   [[[UIAlertView alloc] initWithTitle:@"Game Level" message:[NSString stringWithFormat:@"Game Level value = %@", [Crittercism valueForKey:@"Game Level"]] delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil] show];
        
        
        [[[UIAlertView alloc] initWithTitle:@"Missing SDK part" message:@"No valueForKey: in SDK" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil] show];
        
    }
    
    else if([uniqueThing hasSuffix:@"'"])
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


- (void) tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    
    [self performCommand:[self.tView cellForRowAtIndexPath:indexPath].textLabel.text];
    [self performSelector:@selector(fadeSelection:) withObject:[NSNumber numberWithBool:YES] afterDelay:0.3];
}

- (void) fadeSelection:(BOOL)animated
{
    NSIndexPath*    selection = [self.tView indexPathForSelectedRow];
    if (selection) {
        [self.tView deselectRowAtIndexPath:selection animated:animated];
    }
}

@end
