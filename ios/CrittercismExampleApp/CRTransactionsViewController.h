//
//  TransactionsViewController.h
//  CrittercismExampleApp
//
//  Created by Einar Vollset on 11/13/14.
//  Copyright (c) 2014 Crittercism. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface CRTransactionsViewController : UIViewController <UITableViewDataSource, UITableViewDelegate>
@property (weak, nonatomic) IBOutlet UITableView *tView;


@end
