//
//  CRConsoleViewControllerTableViewController.m
//  CrittercismExampleApp
//
//  Created by Einar Vollset on 1/16/15.
//  Copyright (c) 2015 Crittercism. All rights reserved.
//
#import "GlobalLog.h"
#import "CRConsoleViewControllerTableViewController.h"

@interface CRConsoleViewControllerTableViewController  () <UIDocumentInteractionControllerDelegate>

@property (nonatomic, retain) UIDocumentInteractionController *interaction;
@end

@implementation CRConsoleViewControllerTableViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void) viewDidAppear:(BOOL)animated
{
    [super viewDidAppear:animated];
    
    [self.tableView reloadData];
}



#pragma mark - Table view data source

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    // Return the number of sections.
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    // Return the number of rows in the section.
    return [[GlobalLog sharedLog] logCount];
}


- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:@"SimpleCell" forIndexPath:indexPath];
    
    cell.textLabel.text = [[GlobalLog sharedLog] logItemAtIndex:(int)indexPath.row];
    
    return cell;
}


/*
// Override to support conditional editing of the table view.
- (BOOL)tableView:(UITableView *)tableView canEditRowAtIndexPath:(NSIndexPath *)indexPath {
    // Return NO if you do not want the specified item to be editable.
    return YES;
}
*/

/*
// Override to support editing the table view.
- (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath {
    if (editingStyle == UITableViewCellEditingStyleDelete) {
        // Delete the row from the data source
        [tableView deleteRowsAtIndexPaths:@[indexPath] withRowAnimation:UITableViewRowAnimationFade];
    } else if (editingStyle == UITableViewCellEditingStyleInsert) {
        // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view
    }   
}
*/

/*
// Override to support rearranging the table view.
- (void)tableView:(UITableView *)tableView moveRowAtIndexPath:(NSIndexPath *)fromIndexPath toIndexPath:(NSIndexPath *)toIndexPath {
}
*/

/*
// Override to support conditional rearranging of the table view.
- (BOOL)tableView:(UITableView *)tableView canMoveRowAtIndexPath:(NSIndexPath *)indexPath {
    // Return NO if you do not want the item to be re-orderable.
    return YES;
}
*/

/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

- (IBAction)trash:(id)sender
{
    [[GlobalLog sharedLog] clearLog];
    [self.tableView reloadData];
}

- (IBAction)flyIt:(id)sender
{
    NSMutableString *logText = [NSMutableString string];
    for(int i = 0; i < [[GlobalLog sharedLog] logCount]; i++)
    {
        [logText appendString:[NSString stringWithFormat:@"%@\n",[[GlobalLog sharedLog] logItemAtIndex:i]]];
    }

    
    UIActivityViewController* activityViewController = [[UIActivityViewController alloc] initWithActivityItems:@[logText] applicationActivities:nil];
    [self presentViewController:activityViewController animated:YES completion:nil];


}
                                                    


@end
