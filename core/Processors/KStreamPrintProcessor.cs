﻿using System;
using System.Collections.Generic;
using System.Text;
using kafka_stream_core.Stream.Internal.Graph;

namespace kafka_stream_core.Processors
{
    internal class KStreamPrintProcessor<K, V> : AbstractProcessor<K, V>
    {
        private PrintForeachAction<K, V> actionPrint;

        public KStreamPrintProcessor(PrintForeachAction<K, V> actionPrint)
        {
            this.actionPrint = actionPrint;
        }

        public override object Clone()
        {
            var p= new KStreamPrintProcessor<K, V>(this.actionPrint);
            p.StateStores = new List<string>(this.StateStores);
            return p;
        }

        public override void Process(K key, V value)
        {
            actionPrint.Apply(key, value);
        }

        public override void Close()
        {
            base.Close();
            actionPrint.Close();
        }
    }
}
