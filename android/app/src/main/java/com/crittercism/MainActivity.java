package com.crittercism;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;
import android.support.v4.app.FragmentTransaction;
import android.support.v4.view.ViewPager;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;

import com.crittercism.app.Crittercism;

import com.crittercism.fragments.ErrorFragment;
import com.crittercism.fragments.NetworkFragment;
import com.crittercism.fragments.OtherFragment;
import com.crittercism.fragments.TransactionFragment;

public class MainActivity extends ActionBarActivity implements ActionBar.TabListener {

    private ViewPager viewPager;
    private ActionBar actionBar;
    private TabPagerAdapter tabPagerAdapter;

    private String[] tabs = { "Error", "Network", "Txns", "Other" };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        Crittercism.initialize(getApplicationContext(), "YOUR APP ID GOES HERE");
        setContentView(R.layout.activity_work);

        this.viewPager = (ViewPager)findViewById(R.id.pager);
        this.actionBar = getSupportActionBar();

        this.tabPagerAdapter = new TabPagerAdapter(getSupportFragmentManager());

        this.viewPager.setAdapter(this.tabPagerAdapter);

        this.actionBar.setHomeButtonEnabled(false);
        this.actionBar.setDisplayShowTitleEnabled(false);
        this.actionBar.setNavigationMode(ActionBar.NAVIGATION_MODE_TABS);

        for (String tabName : this.tabs) {
            actionBar.addTab(actionBar.newTab().setText(tabName).setTabListener(this));
        }
    }

    @Override
    public void onTabSelected(ActionBar.Tab tab, FragmentTransaction fragmentTransaction) {
        this.viewPager.setCurrentItem(tab.getPosition());
    }

    @Override
    public void onTabUnselected(ActionBar.Tab tab, FragmentTransaction fragmentTransaction) {

    }

    @Override
    public void onTabReselected(ActionBar.Tab tab, FragmentTransaction fragmentTransaction) {

    }

    private static class TabPagerAdapter extends FragmentStatePagerAdapter {
        public TabPagerAdapter(FragmentManager fm) {
            super(fm);
        }

        @Override
        public Fragment getItem(int i) {
            switch (i) {
                case 0:
                    return new ErrorFragment();
                case 1:
                    return new NetworkFragment();
                case 2:
                    return new TransactionFragment();
                case 3:
                    return new OtherFragment();
                default:
                    throw new AssertionError("Unrecognized tab: " + i);
            }
        }

        @Override
        public int getCount() {
            return 4;
        }
    }
}

