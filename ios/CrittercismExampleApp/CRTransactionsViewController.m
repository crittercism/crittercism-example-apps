//
//  TransactionsViewController.m
//  CrittercismExampleApp
//
//  Created by Einar Vollset on 11/13/14.
//  Copyright (c) 2014 Crittercism. All rights reserved.
//

#import "CRTransactionsViewController.h"
#import "Crittercism.h"
#import "GlobalLog.h"

@interface CRTransactionsViewController ()

@property (nonatomic, retain) NSArray *txNames;

@end

@implementation CRTransactionsViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    self.txNames = @[@"TxOne", @"TxTwo", @"Mornington Crescent"];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}


#pragma mark - Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    return 3;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {


    return 5;

}


- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{


    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:@"SimpleCell" forIndexPath:indexPath];

    if(indexPath.row == 0)
    {
        cell.textLabel.text = [NSString stringWithFormat:@"Tx %li: Begin ",indexPath.section + 1];
    }
    else if(indexPath.row == 1)
    {
        cell.textLabel.text = [NSString stringWithFormat:@"Tx %li: End  ",(long)indexPath.section + 1];
    }
    else if(indexPath.row == 2)
    {
        cell.textLabel.text = [NSString stringWithFormat:@"Tx %li: Fail ",(long)indexPath.section + 1];
    }
    else if(indexPath.row == 3)
    {
        cell.textLabel.text = [NSString stringWithFormat:@"Tx %li: Add 1 ",(long)indexPath.section + 1];
    }
    else if(indexPath.row == 4)
    {
        cell.textLabel.text = [NSString stringWithFormat:@"Tx %li: Get Value",(long)indexPath.section + 1];
    }
    else
    {
        assert(NO);
    }

    return cell;

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
    return [NSString stringWithFormat:@"Transaction %li:", (long)section];
}

- (void)hitButton:(UIButton *)sender
{
    NSLog(@"%@", sender.titleLabel.text);
    [self performCommand:sender.titleLabel.text];
}


- (void) performCommand:(NSString *)command
{
    NSLog(@"%@", command);
    [[GlobalLog sharedLog] logActionString:[NSString stringWithFormat:@"[Transactions]: %@", command]];

    NSArray *components = [command componentsSeparatedByString:@" "];

    NSString *transactionName = [self.txNames objectAtIndex:[[components objectAtIndex:1] intValue]-1];
    NSString *what = [components objectAtIndex:2];


    if([what isEqualToString:@"Begin"])
    {
        [Crittercism beginTransaction:transactionName];

    }
    else if([what isEqualToString:@"End"])
    {
        [Crittercism endTransaction:transactionName];
    }
    else if([what isEqualToString:@"Fail"])
    {
        [Crittercism failTransaction:transactionName];

    }
    else if([what isEqualToString:@"Add"])
    {
        if([Crittercism valueForTransaction:transactionName] < 0)
            [Crittercism setValue:1 forTransaction:transactionName];
        else
            [Crittercism setValue:[Crittercism valueForTransaction:transactionName] + 1 forTransaction:transactionName];


    }
    else if([what isEqualToString:@"Get"])
    {
        [[[UIAlertView alloc] initWithTitle:transactionName message:[NSString stringWithFormat:@"Transaction value = %i", [Crittercism valueForTransaction:transactionName]] delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil] show];
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
