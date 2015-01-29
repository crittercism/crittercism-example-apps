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
    self.txNames = [[NSBundle mainBundle] objectForInfoDictionaryKey:@"txNames"];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}


#pragma mark - Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    return self.txNames.count;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {

    return 5;

}


- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{

    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:@"SimpleCell" forIndexPath:indexPath];

    NSString *txText = [NSString stringWithFormat:@"Tx \"%@\"", self.txNames[indexPath.section]];

    if(indexPath.row == 0)
    {
        cell.textLabel.text = [NSString stringWithFormat:@"%@: Begin ", txText];
    }
    else if(indexPath.row == 1)
    {
        cell.textLabel.text = [NSString stringWithFormat:@"%@: End  ", txText];
    }
    else if(indexPath.row == 2)
    {
        cell.textLabel.text = [NSString stringWithFormat:@"%@: Fail ", txText];
    }
    else if(indexPath.row == 3)
    {
        cell.textLabel.text = [NSString stringWithFormat:@"%@: Add 1 ", txText];
    }
    else if(indexPath.row == 4)
    {
        cell.textLabel.text = [NSString stringWithFormat:@"%@: Get Value", txText];
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
    return [NSString stringWithFormat:@"Transaction \"%@\":", self.txNames[section]];
}

- (void) performCommand:(NSString *)what forTx:(NSString *)txName
{
    NSLog(@"%@ %@", what, txName);
    [[GlobalLog sharedLog] logActionString:[NSString stringWithFormat:@"[Transactions]: %@ %@", what, txName]];

    if([what isEqualToString:@"Begin"])
    {
        [Crittercism beginTransaction:txName];
    }
    else if([what isEqualToString:@"End"])
    {
        [Crittercism endTransaction:txName];
    }
    else if([what isEqualToString:@"Fail"])
    {
        [Crittercism failTransaction:txName];
    }
    else if([what isEqualToString:@"Add"])
    {
        if([Crittercism valueForTransaction:txName] < 0)
            [Crittercism setValue:1 forTransaction:txName];
        else
            [Crittercism setValue:[Crittercism valueForTransaction:txName] + 1 forTransaction:txName];
    }
    else if([what isEqualToString:@"Get"])
    {
        [[[UIAlertView alloc] initWithTitle:txName message:[NSString stringWithFormat:@"Transaction value = %i", [Crittercism valueForTransaction:txName]] delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil] show];
    }
    else
    {
        NSString *msg = [NSString stringWithFormat:@"%@ %@", what, txName];
        [[[UIAlertView alloc] initWithTitle:msg message:@"" delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil] show];
    }
}


- (void) tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath
{
    NSString *what;

    switch (indexPath.row) {
        case 0: what = @"Begin"; break;
        case 1: what = @"End"; break;
        case 2: what = @"Fail"; break;
        case 3: what = @"Add"; break;
        case 4: what = @"Get"; break;
        default: assert(NO);
    }

    NSString *txName = self.txNames[indexPath.section];

    [self performCommand:what forTx:txName];
    [self performSelector:@selector(fadeSelection:) withObject:[NSNumber numberWithBool:YES] afterDelay:0.3];
}

- (void) fadeSelection:(BOOL)animated
{
    NSIndexPath* selection = [self.tView indexPathForSelectedRow];
    if (selection) {
        [self.tView deselectRowAtIndexPath:selection animated:animated];
    }
}


@end
